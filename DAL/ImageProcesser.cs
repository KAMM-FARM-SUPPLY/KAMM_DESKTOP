using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Net;
using System.Data;

namespace KAMM_FARM_SERVICES.DAL
{
    public class ImageProcesser
    {
        public static async  Task<Image> resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        public static async  Task<Image> MakeCircleImage(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (GraphicsPath gpImg = new GraphicsPath())
            {
                gpImg.AddEllipse(0, 0, img.Width - 5, img.Height);
                using (Graphics grp = Graphics.FromImage(bmp))
                {
                    grp.Clear(Color.Transparent);
                    grp.SetClip(gpImg);
                    grp.DrawImage(img, Point.Empty);
                }
            }
            return bmp;
        }

        public static async Task<Image> create_img(string file , Size pic_size, bool circled = false)
        {

            if ((file != "") && (file != null))
            {
                var wc = new WebClient();
                try
                {
                    Image x = Image.FromStream(wc.OpenRead(file));
                    Image resized = await resizeImage(x, pic_size);
                    if (circled)
                    {
                        return await MakeCircleImage(resized);
                    }
                    return resized;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("The picture seems to have been deleted on the server");
                }
                finally
                {
                    
                }
                return null;
            }
            else
            {
                System.Drawing.Image imgS = (Image)KAMM_FARM_SERVICES.Properties.Resources.Untitled_11;
                Image resized = await resizeImage(imgS, pic_size);
                if (circled)
                {
                    return await MakeCircleImage(resized);
                }
                return resized;
            }
        }

        public static async Task<DataTable> LazyloadFarmers(dynamic results)
        {
            DataTable temp = new DataTable();
            if (results != null)
            {
                dynamic farmers_hold = results;


                //Creating a dataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("Active", typeof(bool));
                dt.Columns.Add("Picture", typeof(Image));
                dt.Columns.Add("Name", typeof(String));
                dt.Columns.Add("Gender", typeof(String));
                dt.Columns.Add("Phone number", typeof(String));
                dt.Columns.Add("NIN", typeof(String));

                dt.Columns.Add("Total land acreage", typeof(Int32));
                dt.Columns.Add("Coffee acreage", typeof(Int32));
                dt.Columns.Add("No of trees", typeof(Int32));
                dt.Columns.Add("Unproductive trees", typeof(Int32));
                dt.Columns.Add("Coffee production", typeof(Int32));
                dt.Columns.Add("Signature", typeof(Image));


                for (int i = 0; i < farmers_hold.Count; i++)
                {
                    dt.Rows.Add(
                        //true,
                        farmers_hold[i].Active,
                        await create_img(farmers_hold[i].Profile_picture.ToString(), new Size(70, 70)),
                        farmers_hold[i].Name,
                        farmers_hold[i].Gender,
                        farmers_hold[i].Phone_number,
                        farmers_hold[i].NIN_no,
                        farmers_hold[i].Total_land_acreage,
                        farmers_hold[i].Coffee_acreage,
                        farmers_hold[i].No_of_trees,
                        farmers_hold[i].Unproductive_trees,
                        farmers_hold[i].Ov_coffee_prod,
                        await create_img(farmers_hold[i].Signature.ToString(), new Size(70, 70))
                        );
                }
                return dt;

            }
            return temp;

        }
    }
}
