﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace ET.Server
{
	[EntitySystemOf(typeof(DBComponent))]
	[FriendOf(typeof(DBComponent))]
    public static partial class DBComponentSystem
    {
	    [EntitySystem]
	    private static void Awake(this DBComponent self, string dbConnection, string dbName, int zone)
		{
			self.mongoClient = new MongoClient(dbConnection);
			self.database = self.mongoClient.GetDatabase(dbName);
		}

	    private static IMongoCollection<T> GetCollection<T>(this DBComponent self, string collection = null)
	    {
		    return self.database.GetCollection<T>(collection ?? typeof (T).FullName);
	    }

	    private static IMongoCollection<Entity> GetCollection(this DBComponent self, string name)
	    {
		    return self.database.GetCollection<Entity>(name);
	    }
	    
	    #region Query

	    public static async ETTask<T> Query<T>(this DBComponent self, long id, string collection = null) where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, id % DBComponent.TaskCount))
		    {
			    var cursor = await self.GetCollection<T>(collection).FindAsync(d => d.Id == id);

			    return await cursor.FirstOrDefaultAsync();
		    }
	    }

	    public static async ETTask<Entity> Query(this DBComponent self, long id, string collection)
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, id % DBComponent.TaskCount))
		    {
			    var cursor = await self.GetCollection(collection).FindAsync(d => d.Id == id);
			    return await cursor.FirstOrDefaultAsync();
		    }
	    }
	    
	    public static async ETTask<List<T>> Query<T>(this DBComponent self, Expression<Func<T, bool>> filter, string collection = null)
			    where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, RandomGenerator.RandInt64() % DBComponent.TaskCount))
		    {
			    var cursor = await self.GetCollection<T>(collection).FindAsync(filter);

			    return await cursor.ToListAsync();
		    }
	    }

	    public static async ETTask<List<T>> Query<T>(this DBComponent self, long taskId, Expression<Func<T, bool>> filter, string collection = null)
			    where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, taskId % DBComponent.TaskCount))
		    {
			    var cursor = await self.GetCollection<T>(collection).FindAsync(filter);

			    return await cursor.ToListAsync();
		    }
	    }
	    
	    public static async ETTask Query(this DBComponent self, long id, List<string> collectionNames, List<Entity> result)
	    {
		    if (collectionNames == null || collectionNames.Count == 0)
		    {
			    return;
		    }

		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, id % DBComponent.TaskCount))
		    {
			    foreach (string collectionName in collectionNames)
			    {
				    var cursor = await self.GetCollection(collectionName).FindAsync(d => d.Id == id);

				    var e = await cursor.FirstOrDefaultAsync();

				    if (e == null)
				    {
					    continue;
				    }

				    result.Add(e);
			    }
		    }
	    }

	    public static async ETTask Query(this DBComponent self, long id, List<string> collectionNames, Dictionary<string, Entity> result)
	    {
		    if (collectionNames == null || collectionNames.Count == 0)
		    {
			    return;
		    }

		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, id % DBComponent.TaskCount))
		    {
			    foreach (string collectionName in collectionNames)
			    {
				    var cursor = await self.GetCollection(collectionName).FindAsync(d => d.Id == id);
				    var e = await cursor.FirstOrDefaultAsync();
				    if (e == null)
				    {
					    continue;
				    }

				    result.Add(collectionName, e);
			    }
		    }
	    }

	    public static async ETTask<List<T>> QueryJson<T>(this DBComponent self, string json, string collection = null) where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, RandomGenerator.RandInt64() % DBComponent.TaskCount))
		    {
			    FilterDefinition<T> filterDefinition = new JsonFilterDefinition<T>(json);
			    var cursor = await self.GetCollection<T>(collection).FindAsync(filterDefinition);
			    return await cursor.ToListAsync();
		    }
	    }

	    public static async ETTask<List<T>> QueryJson<T>(this DBComponent self, long taskId, string json, string collection = null) where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, RandomGenerator.RandInt64() % DBComponent.TaskCount))
		    {
			    FilterDefinition<T> filterDefinition = new JsonFilterDefinition<T>(json);
			    var cursor = await self.GetCollection<T>(collection).FindAsync(filterDefinition);
			    return await cursor.ToListAsync();
		    }
	    }

	    #endregion

	    #region Insert

	    public static async ETTask InsertBatch<T>(this DBComponent self, IEnumerable<T> list, string collection = null) where T: Entity
	    {
		    if (collection == null)
		    {
			    collection = typeof (T).FullName;
		    }
		    
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, RandomGenerator.RandInt64() % DBComponent.TaskCount))
		    {
			    await self.GetCollection(collection).InsertManyAsync(list);
		    }
	    }

	    #endregion

	    #region Save

	    public static async ETTask Save<T>(this DBComponent self, T entity, string collection = null) where T : Entity
	    {
		    if (entity == null)
		    {
			    Log.Error($"save entity is null: {typeof (T).FullName}");

			    return;
		    }
		    
		    if (collection == null)
		    {
			    collection = entity.GetType().FullName;
		    }

		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, entity.Id % DBComponent.TaskCount))
		    {
			    await self.GetCollection(collection).ReplaceOneAsync(d => d.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
		    }
	    }

	    public static async ETTask Save<T>(this DBComponent self, long taskId, T entity, string collection = null) where T : Entity
	    {
		    if (entity == null)
		    {
			    Log.Error($"save entity is null: {typeof (T).FullName}");

			    return;
		    }

		    if (collection == null)
		    {
			    collection = entity.GetType().FullName;
		    }

		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, taskId % DBComponent.TaskCount))
		    {
			    await self.GetCollection(collection).ReplaceOneAsync(d => d.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
		    }
	    }

	    public static async ETTask Save(this DBComponent self, long id, List<Entity> entities)
	    {
		    if (entities == null)
		    {
			    Log.Error($"save entity is null");
			    return;
		    }

		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, id % DBComponent.TaskCount))
		    {
			    foreach (var entity in entities)
			    {
				    if (entity == null)
				    {
					    continue;
				    }

				    await self.GetCollection(entity.GetType().FullName)
						    .ReplaceOneAsync(d => d.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
			    }
		    }
	    }

	    public static async ETTask SaveNotWait<T>(this DBComponent self, T entity, long taskId = 0, string collection = null) where T : Entity
	    {
		    if (taskId == 0)
		    {
			    await self.Save(entity, collection);

			    return;
		    }

		    await self.Save(taskId, entity, collection);
	    }

	    #endregion

	    #region Remove
	    
	    public static async ETTask<long> Remove<T>(this DBComponent self, long id, string collection = null) where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, id % DBComponent.TaskCount))
		    {
			    var result = await self.GetCollection<T>(collection).DeleteOneAsync(d => d.Id == id);

			    return result.DeletedCount;
		    }
	    }

	    public static async ETTask<long> Remove<T>(this DBComponent self, long taskId, long id, string collection = null) where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, taskId % DBComponent.TaskCount))
		    {
			    var result = await self.GetCollection<T>(collection).DeleteOneAsync(d => d.Id == id);

			    return result.DeletedCount;
		    }
	    }

	    public static async ETTask<long> Remove<T>(this DBComponent self, Expression<Func<T, bool>> filter, string collection = null) where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, RandomGenerator.RandInt64() % DBComponent.TaskCount))
		    {
			    var result = await self.GetCollection<T>(collection).DeleteManyAsync(filter);

			    return result.DeletedCount;
		    }
	    }

	    public static async ETTask<long> Remove<T>(this DBComponent self, long taskId, Expression<Func<T, bool>> filter, string collection = null)
			    where T : Entity
	    {
		    using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, taskId % DBComponent.TaskCount))
		    {
			    var result = await self.GetCollection<T>(collection).DeleteManyAsync(filter);

			    return result.DeletedCount;
		    }
	    }

	    #endregion
    }
}