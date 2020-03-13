﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DC.Scratch.GameOfLife.Win.Converters
{
    public class BoolBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}