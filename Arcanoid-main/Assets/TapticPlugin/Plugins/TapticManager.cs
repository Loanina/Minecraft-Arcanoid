#if UNITY_IPHONE && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace TapticPlugin
{
    public enum NotificationFeedback
    {
        Success,
        Warning,
        Error
    }


    public enum ImpactFeedback
    {
        Light,
        Medium,
        Heavy
    }

    public static class TapticManager
    {
        public static void Impact(ImpactFeedback feedback)
        {
            if(!IsActivity()) return;
            
            _unityTapticImpact((int) feedback);
        }

        public static void Selection()
        {
            if(!IsActivity()) return;
            
            _unityTapticSelection();
        }

        private static bool IsActivity()
        {
            return _unityTapticIsSupport();
        }

        #region DllImport

#if UNITY_IPHONE && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void _unityTapticNotification(int type);
        [DllImport("__Internal")]
        private static extern void _unityTapticSelection();
        [DllImport("__Internal")]
        private static extern void _unityTapticImpact(int style);
        [DllImport("__Internal")]
        private static extern bool _unityTapticIsSupport();
#else
        private static void _unityTapticNotification(int type) { }

        private static void _unityTapticSelection() { }

        private static void _unityTapticImpact(int style) { }

        private static bool _unityTapticIsSupport() { return false; }
#endif

        #endregion // DllImport
    }

}