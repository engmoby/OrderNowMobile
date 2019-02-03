
using Android.Content;   
using Xamarin.Forms;  
using Xamarin.Forms.Platform.Android;  
[assembly: ExportRenderer(typeof(ListView), typeof(OrderNow.Droid.listviewBarDisable))]  
namespace OrderNow.Droid
{
    public class listviewBarDisable : ListViewRenderer
    {
        Context _context;
        public listviewBarDisable(Context context) : base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.VerticalScrollBarEnabled = false;
            }
        }
    }
}