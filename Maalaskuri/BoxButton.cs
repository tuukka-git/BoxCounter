using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxCounter
{
    //Button that changes color on click
    public class BoxButton : System.Windows.Forms.Button
    {
        public int colornum;
        public BoxButton()
        {
            colornum = 0;
            this.BackColor = colorList[colornum];
            this.ForeColor = colorList[colornum];
        }
        //changes color index
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
        //new index is used  to change color
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
