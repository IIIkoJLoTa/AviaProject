using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FlyInfoModal : Form
    {
        PictureBox pc = new PictureBox();
        PictureBox cl = new PictureBox();
        List<Fly> FlyList = new List<Fly>();
        internal FlyInfoModal(List<Fly> FlyListC)
        {
            FlyList = FlyListC;
            InitializeComponent();
        }

        private void FlyInfoModal_Load(object sender, EventArgs e)
        {
            if (FlyList.Count > 0)
            {
                int items = 10;
                foreach (var x in FlyList)
                {
                    FlyInfo Block = new FlyInfo(x);
                    Block.Location = new Point(5, items);
                    this.Controls.Add(Block);
                    items += 105;
                }
                cl.Width = Properties.Resources.flyclose.Width;
                cl.Height = Properties.Resources.flyclose.Height;
                cl.Image = Properties.Resources.flyclose;
                cl.Location = new Point(ClientSize.Width / 2 - cl.Size.Width / 2, items);
                cl.Anchor = AnchorStyles.None;
                this.Controls.Add(cl);
                cl.MouseClick += new MouseEventHandler(Close);

            }
            else
            {
                pc.Width = Properties.Resources.nothing.Width;
                pc.Height = Properties.Resources.nothing.Height;
                pc.Image = Properties.Resources.nothing;
                pc.Location =new Point(ClientSize.Width / 2 - pc.Size.Width / 2, ClientSize.Height / 2 - pc.Size.Height / 2);
                pc.Anchor = AnchorStyles.None;
                this.Controls.Add(pc);
                this.BackColor = Color.White;

                cl.Width = Properties.Resources.flyclose.Width;
                cl.Height = Properties.Resources.flyclose.Height;
                cl.Image = Properties.Resources.flyclose;
                cl.Location = new Point(ClientSize.Width / 2 - cl.Size.Width / 2, ClientSize.Height / 2 + pc.Size.Height);
                cl.Anchor = AnchorStyles.None;
                this.Controls.Add(cl);
                cl.MouseClick += new MouseEventHandler(Close);
            }
        }
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
