﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace JobProcessor.App.App_Start
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
        new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterServices(container);
            return container;
        });

        public static IUnityContainer Container => container.Value;

        private static void RegisterServices(IUnityContainer container)
        {

        }
    }
}