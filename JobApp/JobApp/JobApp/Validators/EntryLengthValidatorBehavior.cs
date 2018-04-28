using Xamarin.Forms;

namespace JobApp.Validators
{
    /**
     *  Inspired by: https://stackoverflow.com/questions/25086881/restricting-input-length-and-characters-for-entry-field-in-xamarin-forms
     */
    public class EntryLengthValidatorBehavior : Behavior<Entry>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            var dif = entry.Text.Length - this.MaxLength;

            if (dif > 0)
            {
                entry.Text.Remove(entry.Text.Length - dif);
            }
        }
    }
}
