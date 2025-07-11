﻿namespace ET
{
    [Invoke((long)MailBoxType.UnOrderedMessage)]
    public class MailBoxType_UnOrderedMessageHandler: AInvokeHandler<MailBoxInvoker>
    {
        public override void Handle(MailBoxInvoker args)
        {
            HandleAsync(args).Coroutine();
        }
        
        private static async ETTask HandleAsync(MailBoxInvoker args)
        {
            var mailBoxComponent = args.MailBoxComponent;
            
            var messageObject = args.MessageObject;
            
            await MessageDispatcher.Instance.Handle(mailBoxComponent.Parent, args.FromAddress, messageObject);
        }
    }
}