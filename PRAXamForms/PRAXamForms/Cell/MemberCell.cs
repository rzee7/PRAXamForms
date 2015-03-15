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
        public MemberCell()
        {
            StackLayout viewLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { MemberImageView, CraeteLayout() }
            };
            View = viewLayout;
        }

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
                image.TranslateTo(image.ParentView.Width, 0);
                return image;
            }
        }

        StackLayout CraeteLayout()
        {
            #region Label for name

            Label nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            nameLabel.SetBinding(Label.TextProperty, "FullName");

            #endregion

            #region Create a label for the title.

            Label titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
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
    }
}
