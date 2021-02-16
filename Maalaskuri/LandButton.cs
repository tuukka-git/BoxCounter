using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxCounter
{
    public class LandButton : System.Windows.Forms.Button
    {
        public int colornum;
        public LandButton()
        {
            colornum = 0;
            this.BackColor = colorList[colornum];
            this.ForeColor = colorList[colornum];
        }
        public void ChangeColor() 
        {
            if (colornum < colorList.Length - 1)
            {
                this.colornum += 1;
            }
            else{
                this.colornum = 0;
            } 
        }
        public int getColorNum()
        {
            return this.colornum;
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ChangeColor();
            this.BackColor = colorList[colornum];
            this.ForeColor = colorList[colornum];
            return;

        }
        private Color[] colorList = { Color.White, Color.Blue, Color.Red, Color.Green};
    }
   

}
