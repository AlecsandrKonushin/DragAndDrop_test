using System;
using System.Linq;
using Core.Controllers;
using UnityEngine;

namespace EventsSystem
{
    [CreateAssetMenu(fileName = "EventsController", menuName = "Controllers/EventsController")]
    public class EventsController : Controller
    {
        private Action changeLocalization;

        #region CHANGE_LOCALIZATION

        public void SubscribeOnChangeLocalization(Action sender)
        {
            if (changeLocalization != null && changeLocalization.GetInvocationList().Contains(sender))
            {
                Debug.LogError($"Try 2 subscribes on ChangeLocalization");
            }
            else
            {
                changeLocalization += sender;
            }
        }

        public void UnsubscribeOnChangeLocalization(Action sender)
        {
            changeLocalization -= sender;
        }

        public void ChangeLocalization()
        {
            changeLocalization?.Invoke();
        }

        #endregion
    }
}