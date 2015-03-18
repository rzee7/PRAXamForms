using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms.Cell
{
    public class MemberCell : ViewCell
    {
        #region Constructor

        public MemberCell()
        {
            #region View Layout

            StackLayout viewLayout = new StackLayout
            {
               // BackgroundColor = Color.Gray,
                Orientation = StackOrientation.Horizontal,
                Children = { MemberImageView, CellLayout() }
            };

            View = viewLayout;
            viewLayout.Children[0].LayoutTo(new Rectangle(0, 0, 40, 40), 2500, Easing.BounceIn);

            #endregion

            #region Another Way to Animate View

            //viewLayout.Children[0].Animate("", x =>
            //{
            //    viewLayout.Children[0].TranslateTo(0, 0);
            //}, length: 500);

            #endregion
        }

        #endregion

        #region Image Cell

        static Image MemberImageView
        {
            get
            {
                Image image = new Image
                {
                    HorizontalOptions = LayoutOptions.Start
                };
                image.SetBinding(Image.SourceProperty, new Binding("ProfileImage"));
                image.WidthRequest = image.HeightRequest = 40;
                return image;
            }
        }

        #endregion

        #region Image Layout

        StackLayout CellLayout()
        {
            #region Label for name

            Label nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nameLabel.SetBinding(Label.TextProperty, "FullName");

            #endregion

            #region Create a label for the title.

            Label titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TranslationY = -5
            };
            titleLabel.SetBinding(Label.TextProperty, "Title");

            #endregion

            #region Adding Controls to Stack Layout

            StackLayout memberLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { nameLabel, titleLabel }
            };

            #endregion

            return memberLayout;
        }

        #endregion
    }
}
