using GHelper.Input;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GHelper.BacklightRemap
{
public class BacklightRemapHandler : ApplicationContext
{
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;

    private LowLevelKeyboardProc _proc;
    private IntPtr _hookId = IntPtr.Zero;

    public BacklightRemapHandler()
    {
        _proc = HookCallback;
        _hookId = SetHook(_proc);
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);

            // Check if the pressed key is Page Up or Page Down
            if (vkCode == (int)Keys.PageUp)
            {
                // Run your function for Page Up
                RunFunctionForPageUp();
                return (IntPtr)1;
            }
            else if (vkCode == (int)Keys.PageDown)
            {
                // Run your function for Page Down
                RunFunctionForPageDown();
                return (IntPtr)1;
            }
        }

        return CallNextHookEx(_hookId, nCode, wParam, lParam);
    }

    private static void RunFunctionForPageUp()
    {
        // Your code for Page Up key press
        InputDispatcher.SetBacklight(1);
    }

    private static void RunFunctionForPageDown()
    {
        InputDispatcher.SetBacklight(-1);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [STAThread]
    public void Run()
    {
        // Create and run the KeyPressHandler
        Application.Run(new BacklightRemapHandler());
    }
}

}
