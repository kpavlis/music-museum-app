using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Display;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ergasia_Allilepidrasi
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        WindowsSystemDispatcherQueueHelper m_wsdqHelper;
        Microsoft.UI.Composition.SystemBackdrops.MicaController m_micaController;
        Microsoft.UI.Composition.SystemBackdrops.SystemBackdropConfiguration m_configurationSource;

        IntPtr hWnd = IntPtr.Zero;
        private SUBCLASSPROC SubClassDelegate;

        int x = 1;

        int width = 450;
        int height = 400;

        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref bool attrValue, int attrSize);

        public MainWindow()
        {
            hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);


            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            SizeWindow(appWindow);


            this.InitializeComponent();
            TrySetMicaBackdrop();


            AppWindow.Title = "Music Museum";

            ExtendsContentIntoTitleBar = true;
            SetTitleBar(TitleBar);
        }

        private async Task SizeWindow(AppWindow appWindow)
        {
            var displayList = await DeviceInformation.FindAllAsync
                              (DisplayMonitor.GetDeviceSelector());

            if (!displayList.Any())
                return;

            var monitorInfo = await DisplayMonitor.FromInterfaceIdAsync(displayList[0].Id);



            if (monitorInfo == null)
            {
                width = 450;
                height = 400;
                SubClassDelegate = new SUBCLASSPROC(WindowSubClass);
                bool bReturn = SetWindowSubclass(hWnd, SubClassDelegate, 0, 0);
                
            }
            else
            {
                double dheight = monitorInfo.NativeResolutionInRawPixels.Height / 1.5;
                double dwidth = monitorInfo.NativeResolutionInRawPixels.Width / 1.7;

                height = (int)dheight;
                width = (int)dwidth;
                SubClassDelegate = new SUBCLASSPROC(WindowSubClass);
                bool bReturn = SetWindowSubclass(hWnd, SubClassDelegate, 0, 0);

            }
        }


        bool TrySetMicaBackdrop()
        {
            if (Microsoft.UI.Composition.SystemBackdrops.MicaController.IsSupported())
            {
                m_wsdqHelper = new WindowsSystemDispatcherQueueHelper();
                m_wsdqHelper.EnsureWindowsSystemDispatcherQueueController();

                // Hooking up the policy object
                m_configurationSource = new Microsoft.UI.Composition.SystemBackdrops.SystemBackdropConfiguration();
                this.Activated += Window_Activated;
                this.Closed += Window_Closed;
                ((FrameworkElement)this.Content).ActualThemeChanged += Window_ThemeChanged;

                // Initial configuration state.
                m_configurationSource.IsInputActive = true;
                SetConfigurationSourceTheme();

                m_micaController = new Microsoft.UI.Composition.SystemBackdrops.MicaController();

                // Enable the system backdrop.
                // Note: Be sure to have "using WinRT;" to support the Window.As<...>() call.
                m_micaController.AddSystemBackdropTarget(this.As<ICompositionSupportsSystemBackdrop>());
                m_micaController.SetSystemBackdropConfiguration(m_configurationSource);
                return true; // Succeeded.
            }

            return false; // Mica is not supported on this system.
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            m_configurationSource.IsInputActive = args.WindowActivationState != WindowActivationState.Deactivated;
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            // Make sure any Mica/Acrylic controller is disposed so it doesn't try to
            // use this closed window.
            if (m_micaController != null)
            {
                m_micaController.Dispose();
                m_micaController = null;
            }
            this.Activated -= Window_Activated;
            m_configurationSource = null;
        }

        private void Window_ThemeChanged(FrameworkElement sender, object args)
        {
            if (m_configurationSource != null)
            {
                SetConfigurationSourceTheme();
            }
        }

        private void SetConfigurationSourceTheme()
        {
            switch (((FrameworkElement)this.Content).ActualTheme)
            {
                case ElementTheme.Dark: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Dark; break;
                case ElementTheme.Light: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Light; break;
                case ElementTheme.Default: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Default; break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(PAGE_GENERAL_Customer), this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(PAGE_GENERAL_Staff), this);
        }

        private int WindowSubClass(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData)
        {
            switch (uMsg)
            {
                case WM_GETMINMAXINFO:
                    {
                        MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
                        mmi.ptMinTrackSize.X = width;
                        mmi.ptMinTrackSize.Y = height;
                        Marshal.StructureToPtr(mmi, lParam, false);
                        return 0;
                    }
                    break;
            }
            return DefSubclassProc(hWnd, uMsg, wParam, lParam);
        }

        public delegate int SUBCLASSPROC(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern bool SetWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern int DefSubclassProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        public const int WM_GETMINMAXINFO = 0x0024;

        public struct MINMAXINFO
        {
            public System.Drawing.Point ptReserved;
            public System.Drawing.Point ptMaxSize;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Point ptMinTrackSize;
            public System.Drawing.Point ptMaxTrackSize;
        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.ToString() == "Control" && splitView.IsPaneOpen == false)
            {
                splitView.IsPaneOpen = true;
            }
            else if (e.Key.ToString() == "Control" && splitView.IsPaneOpen == true)
            {
                splitView.IsPaneOpen = false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (x == 1)
            {
                ((FrameworkElement)this.Content).RequestedTheme = ElementTheme.Light;

                x += 1;
            }
            else if (x == 2)
            {
                ((FrameworkElement)this.Content).RequestedTheme = ElementTheme.Dark;
                //var value = true;
                //DwmSetWindowAttribute(hWnd, 20, ref value, System.Runtime.InteropServices.Marshal.SizeOf(value));

                x += 1;

            }
            else if (x == 3)
            {
                ((FrameworkElement)this.Content).RequestedTheme = ElementTheme.Default;
                //var value = false;
                //DwmSetWindowAttribute(hWnd, 20, ref value, System.Runtime.InteropServices.Marshal.SizeOf(value));

                x -= 2;
            }
        }




    }

    class WindowsSystemDispatcherQueueHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        struct DispatcherQueueOptions
        {
            internal int dwSize;
            internal int threadType;
            internal int apartmentType;
        }

        [DllImport("CoreMessaging.dll")]
        private static extern int CreateDispatcherQueueController([In] DispatcherQueueOptions options, [In, Out, MarshalAs(UnmanagedType.IUnknown)] ref object dispatcherQueueController);

        object m_dispatcherQueueController = null;
        public void EnsureWindowsSystemDispatcherQueueController()
        {
            if (Windows.System.DispatcherQueue.GetForCurrentThread() != null)
            {
                // one already exists, so we'll just use it.
                return;
            }

            if (m_dispatcherQueueController == null)
            {
                DispatcherQueueOptions options;
                options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));
                options.threadType = 2;    // DQTYPE_THREAD_CURRENT
                options.apartmentType = 2; // DQTAT_COM_STA

                CreateDispatcherQueueController(options, ref m_dispatcherQueueController);
            }
        }
    }
}
