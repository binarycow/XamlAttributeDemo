using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using JetBrains.Annotations;

namespace XamlAttributeDemo;

public class ColumnLikeControl : DependencyObject
{
    public static readonly DependencyProperty BindingProperty = 
        DependencyProperty.Register(nameof(Binding), typeof(BindingBase), typeof(ColumnLikeControl));

    [XamlItemBindingOfItemsControl]
    public BindingBase? Binding
    {
        get => this.GetValue(BindingProperty) as BindingBase;
        set => this.SetValue(BindingProperty, value);
    }
}

public class DataGridLikeControl : ItemsControl
{
    public ObservableCollection<ColumnLikeControl> Columns { get; } = new();
}

public static class AttachedProperties
{
    public static readonly DependencyProperty AttachedColumnsProperty = DependencyProperty.RegisterAttached(
        "AttachedColumns",
        typeof(ObservableCollection<ColumnLikeControl>),
        typeof(AttachedProperties),
        new FrameworkPropertyMetadata()
    );
    [AttachedPropertyBrowsableForType(typeof(DataGridLikeControl))]
    public static ObservableCollection<ColumnLikeControl>? GetAttachedColumns(DataGridLikeControl target)
        => target.GetValue(AttachedColumnsProperty) as ObservableCollection<ColumnLikeControl>;
    public static void SetAttachedColumns(DataGridLikeControl target, ObservableCollection<ColumnLikeControl> value)
        => target.SetValue(AttachedColumnsProperty, value);
}

