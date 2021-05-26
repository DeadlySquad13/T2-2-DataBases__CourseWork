using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using HappyPocket.DataModel;

namespace HappyPocket
{
    public class HappyPocketWindow : Window
    {
        public HappyPocketContext dbContext;
        public HappyPocketWindow WindowParent { get; set; }
    }
}
