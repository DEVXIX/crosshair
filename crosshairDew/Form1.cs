using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private KeyboardHook _hook = new KeyboardHook();
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private Color crosshairColor = Color.DarkCyan; // Default color
        private int crosshairSize = 20; // Default size

        public Form1()
        {
            InitializeComponent();
            // Set the form to cover the entire primary screen
            this.Bounds = Screen.PrimaryScreen.Bounds;
            // Make the form's background color unique
            this.BackColor = Color.LimeGreen;
            // Set the TransparencyKey to the same color to make it transparent
            this.TransparencyKey = Color.LimeGreen;
            // Remove the window border
            this.FormBorderStyle = FormBorderStyle.None;
            // Keep the form on top
            this.TopMost = true;
            // Set the StartPosition to Manual to prevent overrides
            this.StartPosition = FormStartPosition.Manual;

            // Create a context menu for the tray icon
            trayMenu = new ContextMenuStrip();
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += ExitMenuItem_Click;
            trayMenu.Items.Add(exitMenuItem);

            // Add "Customize" item
            ToolStripMenuItem customizeItem = new ToolStripMenuItem("Customize");
            customizeItem.Click += CustomizeItem_Click;
            trayMenu.Items.Insert(0, customizeItem); // Insert at the beginning of the menu

            // Create a tray icon
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Crosshair App";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40); // Replace with your icon
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;

            // Setup the keyboard hook
            _hook.OnKeyPressed += Hook_OnKeyPressed;

            // Make the form initially visible (crosshair on)
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = false;
        }

        private void CustomizeItem_Click(object sender, EventArgs e)
        {
            using (CustomizationForm customizationForm = new CustomizationForm(crosshairColor, crosshairSize))
            {
                if (customizationForm.ShowDialog() == DialogResult.OK)
                {
                    crosshairColor = customizationForm.SelectedColor;
                    crosshairSize = customizationForm.CrosshairSize;
                    this.Invalidate(); // Redraw the form to update crosshair
                }
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TOOLWINDOW; // Set the Extended Window Style to Tool Window
                return cp;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Remove from taskbar
            this.ShowInTaskbar = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Point center = new Point(Screen.PrimaryScreen.Bounds.Width / 2,
                                     Screen.PrimaryScreen.Bounds.Height / 2);
            int lineLength = crosshairSize;
            using (Pen pen = new Pen(crosshairColor, 2) { Alignment = PenAlignment.Center })
            {
                e.Graphics.DrawLine(pen, center.X - lineLength / 2, center.Y, center.X + lineLength / 2, center.Y);
                e.Graphics.DrawLine(pen, center.X, center.Y - lineLength / 2, center.X, center.Y + lineLength / 2);
            }
        }

        private void Hook_OnKeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.KeyPressed == Keys.End)
            {
                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _hook.Dispose();
                trayIcon?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
