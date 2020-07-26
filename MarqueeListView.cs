using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Champen2019Generator
{
    public enum ScrollBarDirection : int { Horizontal = 0x0, Vertical = 0x1 }
    public enum ScrollCommand : int { Up = 0x0, Down = 0x1, EndScroll = 0x8 }

    public class MarqueeListView : ListView
    {
        protected const int WM_VSCROLL = 0x115;

        private ScrollCommand scrollCommand;
        private int scrollPositionOld;
        public Timer timer;

        public MarqueeListView()
            : base()
        {
            this.timer = new Timer() { Interval = 2};

            this.MarqueeSpeed = 1;

            this.scrollPositionOld = int.MinValue;
            this.scrollCommand = ScrollCommand.Down;

            this.timer.Tick += (sender, e) =>
            {
                int scrollPosition = MarqueeListView.GetScrollPos((IntPtr)this.Handle, (int)ScrollBarDirection.Vertical);
                if (scrollPosition == this.scrollPositionOld)
                {
                    if (this.scrollCommand == ScrollCommand.Down)
                    {
                        this.scrollCommand = ScrollCommand.Up;
                    }
                    else
                    {
                        this.scrollCommand = ScrollCommand.Down;
                    }
                }
                this.scrollPositionOld = scrollPosition;

                MarqueeListView.SendMessage((IntPtr)this.Handle, MarqueeListView.WM_VSCROLL, (IntPtr)this.scrollCommand, IntPtr.Zero);
                MarqueeListView.SendMessage((IntPtr)this.Handle, MarqueeListView.WM_VSCROLL, (IntPtr)ScrollCommand.EndScroll, IntPtr.Zero);
            };
        //    this.timer.Start();
        }

        public int MarqueeSpeed
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x83: // WM_NCCALCSIZE
                    int style = (int)GetWindowLong(this.Handle, GWL_STYLE);
                    if ((style & 0x00200000) == 0x00200000)
                        SetWindowLong(this.Handle, GWL_STYLE, style & ~0x00200000);
                    if ((style & WS_VSCROLL) == WS_VSCROLL)
                        SetWindowLong(this.Handle, GWL_STYLE, style & ~WS_VSCROLL);
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        const int GWL_STYLE = -16;
        const int WS_VSCROLL = 0x00100000;

        public static int GetWindowLong(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
                return (int)GetWindowLong32(hWnd, nIndex);
            else
                return (int)(long)GetWindowLongPtr64(hWnd, nIndex);
        }

        public static int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong)
        {
            if (IntPtr.Size == 4)
                return (int)SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            else
                return (int)(long)SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
