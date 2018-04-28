using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace JobApp.Validators
{
    /**
     * Source: modified EmailValidatorBehavior from
     * https://www.c-sharpcorner.com/article/input-validation-in-xamarin-forms-behaviors/
     */
    public class PhoneValidatorBehavior : Behavior<Entry>
    {
        const string PhoneRegex = @"^(+\d{3})?\d?\d{3}\s?\d{3}\s?\d{3}$";

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = false;
            isValid = (Regex.IsMatch(e.NewTextValue, PhoneRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
