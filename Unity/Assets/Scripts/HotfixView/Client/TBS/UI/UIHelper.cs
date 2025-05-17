﻿namespace ET.Client
{
    public static class UIHelper
    {
        [EnableAccessEntiyChild]
        public static async ETTask<UI> Create(Entity scene, string uiType, UILayer uiLayer)
        {
            return await scene.GetComponent<UIComponent>().Create(uiType, uiLayer);
        }

        [EnableAccessEntiyChild]
        public static async ETTask Remove(Entity scene, string uiType)
        {
            scene.GetComponent<UIComponent>().Remove(uiType);
            await ETTask.CompletedTask;
        }

        [EnableAccessEntiyChild]
        public static async ETTask<UI> TryCreate(Entity scene, string uiType, UILayer uiLayer)
        {
            UI ui = scene.GetComponent<UIComponent>().Get(uiType);
            if (ui == null)
            {
                ui = await scene.GetComponent<UIComponent>().Create(uiType, uiLayer);
            }

            return ui;
        }
    }
}