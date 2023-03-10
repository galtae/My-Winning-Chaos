using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Media;

namespace My_Winning_Chaos_Util
{
    class hooking
    {
        //dll import list
        #region dll 리스트
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);

    
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte vk, byte scan, int flags, ref  int extrainfo); 
        #endregion


        
        //flag list
        #region 플래그들
        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            MOUSE_WHEEL = 0x00000800
        }

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;


        public struct keyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        } 
        #endregion

        #region 각종 변수들
        public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);


        public List<Keys> HookedKeys = new List<Keys>();
        IntPtr hhook = IntPtr.Zero;
        keyboardHookProc khp;
        
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public Keys n1, n2, n4, n5, n7, n8, np,n_change,n_onoff;
        public bool state = false;
        public bool state_for_onoff = true;
        int info;
        SoundPlayer sp = new SoundPlayer();

        #endregion

        #region 생성자 & 소멸자
        public hooking()
        {
            
            khp = new keyboardHookProc(hookProc);
            hook();

        }

        ~hooking()
        {
            unhook();
        } 
        #endregion



        public void hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, khp, hInstance, 0);
            
        }

        /// <summary>
        /// Uninstalls the global hook
        /// </summary>
        public void unhook()
        {
            UnhookWindowsHookEx(hhook);
            
        }


        public int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                KeyEventArgs kea = new KeyEventArgs(key);
               
                if (state == false)
                {
                    KeyDown(this, kea);
                    return CallNextHookEx(hhook, code, wParam, ref lParam);

                }
               
                if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                {
                    if (state== true)
                    {
                        if (key == n_onoff)
                        {
                            if (state_for_onoff == true)
                            {
                                state_for_onoff = false;
                                sp.Stream = Properties.Resources.off;
                                sp.Play();
                                return 1;
                            }

                            if (state_for_onoff == false)
                            {
                                state_for_onoff = true;
                                sp.Stream = Properties.Resources.on;
                                sp.Play();
                                return 1;
                            }
                            
                            
                           
                        }

                        if (state_for_onoff == true)
                        {
                                  
              /* 윈도우키 입력 방지 
                            if (key == Keys.LWin)
                            {
                                return 1;
                            }
               */

                            if (key == n1)
                            {
                                keybd_event((byte)Keys.NumPad1, 0x00, 0, ref info);
                                keybd_event((byte)Keys.NumPad1, 0x00, 2, ref info);
                                return 1;
                            }
                            if (key == n2)
                            {
                                keybd_event((byte)Keys.NumPad2, 0x00, 0, ref info);
                                keybd_event((byte)Keys.NumPad2, 0x00, 2, ref info);
                                return 1;
                            }
                            if (key == n4)
                            {
                                keybd_event((byte)Keys.NumPad4, 0x00, 0, ref info);
                                keybd_event((byte)Keys.NumPad4, 0x00, 2, ref info);
                                return 1;
                            }
                            if (key == n5)
                            {
                                keybd_event((byte)Keys.NumPad5, 0x00, 0, ref info);
                                keybd_event((byte)Keys.NumPad5, 0x00, 2, ref info);
                                return 1;
                            }
                            if (key == n7)
                            {
                                keybd_event((byte)Keys.NumPad7, 0x00, 0, ref info);
                                keybd_event((byte)Keys.NumPad7, 0x00, 2, ref info);
                                return 1;
                            }
                            if (key == n8)
                            {
                                keybd_event((byte)Keys.NumPad8, 0x00, 0, ref info);
                                keybd_event((byte)Keys.NumPad8, 0x00, 2, ref info);
                                return 1;
                            }

                            if (key == Keys.Z || key == n_change || key == n_onoff)
                            {
                                KeyDown(this, kea);
                                return 1;
                            }
                        }
                
                        
                    }
                }

                else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                {
                    KeyUp(this, kea);

                }
                /*
                if (kea.Handled)
                    return 1;
                */
                
            }
            return CallNextHookEx(hhook, code, wParam, ref lParam);
        }
        
    }
}
