using Android.Content;
using Android.Views;
using Android.Widget;
using TestDemo.Droid;

public class ImageAdapter : BaseAdapter
{
    Context context;

    public ImageAdapter(Context c)
    {
        context = c;
    }

    public override int Count { get { return thumbIds.Length; } }

    public override Java.Lang.Object GetItem(int position)
    {
        return null;
    }

    public override long GetItemId(int position)
    {
        return 0;
    }

    // create a new ImageView for each item referenced by the Adapter
    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        ImageView i = new ImageView(context);

        i.SetImageResource(thumbIds[position]);
        i.LayoutParameters = new Gallery.LayoutParams(720, 720);
        i.SetScaleType(ImageView.ScaleType.FitXy);

        return i;
    }

    // references to our images
    int[] thumbIds = {
            Resource.Drawable.bird_1,
            Resource.Drawable.butterfly_1,
            Resource.Drawable.diamond_1
     };
}