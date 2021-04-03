namespace DR.CeritaReliefAvadana.UI.Behaviors
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms;

    // From https://github.com/xamarin/xamarin-forms-samples/blob/master/Behaviors/EventToCommandBehavior/EventToCommandBehavior/Behaviors/BehaviorBase.cs
    public class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Scope = "Method", MessageId = "0", Justification = "Passing null is supported.")]
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Scope = "Method", MessageId = "0", Justification = "Passing null is supported.")]
        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
