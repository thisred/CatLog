﻿namespace ET
{
    [Invoke((long)MailBoxType.OrderedMessage)]
    public class MailBoxType_OrderedMessageHandler: AInvokeHandler<MailBoxInvoker>
    {
        public override void Handle(MailBoxInvoker args)
        {
            HandleInner(args).Coroutine();
        }

        private static async ETTask HandleInner(MailBoxInvoker args)
        {
            var mailBoxComponent = args.MailBoxComponent;
            
            var messageObject = args.MessageObject;

            var fiber = mailBoxComponent.Fiber();
            if (fiber.IsDisposed)
            {
                return;
            }

            long instanceId = mailBoxComponent.InstanceId;
            using (await fiber.Root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Mailbox, mailBoxComponent.ParentInstanceId))
            {
                if (mailBoxComponent.InstanceId != instanceId)
                {
                    if (messageObject is IRequest request)
                    {
                        var resp = MessageHelper.CreateResponse(request.GetType(), request.RpcId, ErrorCore.ERR_NotFoundActor);
                        mailBoxComponent.Root().GetComponent<ProcessInnerSender>().Reply(args.FromAddress, resp);
                    }
                    return;
                }
                await MessageDispatcher.Instance.Handle(mailBoxComponent.Parent, args.FromAddress, messageObject);
            }
        }
    }
}