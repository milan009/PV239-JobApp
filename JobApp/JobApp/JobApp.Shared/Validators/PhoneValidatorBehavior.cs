using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace JobApp.Shared.Validators
{
    /**
     * Source: modified EmailValidatorBehavior from
     * https://www.c-sharpcorner.com/article/input-validation-in-xamarin-forms-behaviors/
     */
    public class PhoneValidatorBehavior : Behavior<Entry>
    {
        const string PhoneRegex = @"^\(?([0-9]{3,4})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{3,4})$";
        public bool IsValid { get; private set; } = true;

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, PhoneRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
