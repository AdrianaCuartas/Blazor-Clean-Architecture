using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza.Razor.Views.Components;
public partial class TopBar
{
    string ImagePath =>
        "_content/" +
        GetType().Assembly.GetName().Name +
        "/images";
}
