using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedLord.App
{
    /// <summary>
    ///     this is a strongly typed wrapper around Session;
    ///     if we ultimately go to another Session provider,
    ///     this lets us swap out the implementation. 
    /// 
    ///     It also ensures that all Session access is centralized
    ///     so we can keep track of what's going into Session to keep it light
    /// </summary>
    public class StateManager
    {
        //Keys
        public const string CurrentCharacterData = "Character";
        private const string CurrentCharacterDataRefreshTime = "CharacterRefreshTime";

        /// <summary>
        ///     Get/Set Customer per session
        ///     Note:  not sure why this was being done per request, except to avoid merge issues --so
        /// </summary>
        public static ViewCustomer ViewCustomer
        {
            get { return GetFromSession<ViewCustomer>(CurrentCustomer); }
            set { SetInSession(CurrentCustomer, value); }
        }

        /// <summary>
        /// Get/Set Customer per session
        /// Note:  not sure why this was being done per request, except to avoid merge issues --so
        /// </summary>
        public static UserPrincipal SavedUser
        {
            get { return GetFromSession<UserPrincipal>(SavedUserName); }
            set { SetInSession(SavedUserName, value); }
        }

        /// <summary>
        /// Last ime customer data was refreshed from database
        /// </summary>
        public static DateTime ViewCustomerRefreshTime
        {
            get { return GetFromSession<DateTime>(CurrentCustomerRefreshTime); }
            set { SetInSession(CurrentCustomerRefreshTime, value); }
        }

        /// <summary>
        /// Get value from session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private static T GetFromSession<T>(string key)
        {
            if (HttpContextFactory.Current != null && HttpContextFactory.Current.Session != null
                && HttpContextFactory.Current.Session[key] != null)
            {
                return (T)HttpContextFactory.Current.Session[key];
            }
            return default(T);
        }

        /// <summary>
        ///     Set value in session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        private static void SetInSession<T>(string key, T obj)
        {
            if (HttpContextFactory.Current != null && HttpContextFactory.Current.Session != null)
                HttpContextFactory.Current.Session.Add(key, obj);
        }


        /// <summary>
        ///     Get value from HttpContext.Items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private static T GetPerRequest<T>(string key)
        {
            if (HttpContextFactory.Current != null && HttpContextFactory.Current.Items != null)
                return (T)(HttpContextFactory.Current.Items.Contains(key) ? HttpContextFactory.Current.Items[key] : default(T));
            return default(T);
        }

        /// <summary>
        ///     Set value in HttpContext.Items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        private static void SetPerRequest<T>(string key, T obj)
        {
            if (HttpContextFactory.Current != null && HttpContextFactory.Current.Items != null)
            {
                if (HttpContextFactory.Current.Items.Contains(key))
                    HttpContextFactory.Current.Items[key] = obj;
                else
                    HttpContextFactory.Current.Items.Add(key, obj);
            }
        }
    }
}