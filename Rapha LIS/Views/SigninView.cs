using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rapha_LIS.Views
{
    public partial class SigninView : MaterialForm
    {
        public SigninView()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
            /*(Primary)0xFFFFFF,  // Pure white background
            (Primary)0xF1F8E9,  // Very light green (subtle medical feel)
            (Primary)0xC8E6C9,  // Slightly darker green (depth)
            (Accent)0x66BB6A,   // Soft green accent (natural and calming)
            TextShade.BLACK     // Black text for contrast
            */
            (Primary)0xFFFFFF,  // Clean white background
    (Primary)0xF3E5F5,  // Very light purple for a premium look
    (Primary)0xCE93D8,  // Soft purple contrast
    (Accent)0xBA68C8,   // Vibrant purple accent
    TextShade.BLACK     // Dark text for easy reading
            );
            guna2ShadowForm1.SetShadowForm(this);

        }


    }
}
