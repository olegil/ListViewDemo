using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;

namespace ListViewDemo
{
	public class SimpleExandableListItem2Adapter: BaseAdapter<Speaker>
	{
		private readonly List<Speaker> _speakers;
		private readonly Activity _activity;

		public SimpleExandableListItem2Adapter (Activity activity, IEnumerable<Speaker> speakers)
		{
			_speakers = speakers.OrderBy (s => s.Name).ToList ();
			_activity = activity;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Speaker this [int index] {
			get { return _speakers [index]; }
		}

		public override int Count {
			get { return _speakers.Count; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView;

			if (view == null) {
				view = _activity.LayoutInflater.Inflate (Android.Resource.Layout.SimpleExpandableListItem2, null);
			}

			var speaker = _speakers [position];

			TextView text1 = view.FindViewById<TextView> (Android.Resource.Id.Text1);
			text1.Text = speaker.Name;

			TextView text2 = view.FindViewById<TextView> (Android.Resource.Id.Text2);
			text2.Text = speaker.Company;

			return view;
		}
	}
}