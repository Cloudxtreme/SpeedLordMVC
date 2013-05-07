using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpeedLord.Dto;

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
        private const string CurrentCharacterData = "Character";
        private const string CurrentCharacterDataRefreshTime = "CharacterRefreshTime";
        private const string SavedUserName = "SavedUser"; //for simulation

        /// <summary>
        ///     Get/Set Customer per session
        /// </summary>
        public static Character CurrentCharacter
        {
            get { return GetFromSession<Character>(CurrentCharacterData); }
            set { SetInSession(CurrentCharacterData, value); }
        }

        /// <summary>
        /// Last time character data was refreshed from database
        /// </summary>
        public static DateTime CurrentCharacterRefreshTime
        {
            get { return GetFromSession<DateTime>(CurrentCharacterDataRefreshTime); }
            set { SetInSession(CurrentCharacterDataRefreshTime, value); }
        }

        /// <summary>
        /// Get/Set Customer per session
        /// </summary>
        public static User CurrentUser
        {
            get { return GetFromSession<User>(SavedUserName); }
            set { SetInSession(SavedUserName, value); }
        }

       

        /// <summary>
        /// Get value from session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private static T GetFromSession<T>(string key)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null
                && HttpContext.Current.Session[key] != null)
            {
                return (T)HttpContext.Current.Session[key];
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
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
                HttpContext.Current.Session.Add(key, obj);
        }


        /// <summary>
        ///     Get value from HttpContext.Items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private static T GetPerRequest<T>(string key)
        {
            if (HttpContext.Current != null && HttpContext.Current.Items != null)
                return (T)(HttpContext.Current.Items.Contains(key) ? HttpContext.Current.Items[key] : default(T));
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
            if (HttpContext.Current != null && HttpContext.Current.Items != null)
            {
                if (HttpContext.Current.Items.Contains(key))
                    HttpContext.Current.Items[key] = obj;
                else
                    HttpContext.Current.Items.Add(key, obj);
            }
        }
    }
}