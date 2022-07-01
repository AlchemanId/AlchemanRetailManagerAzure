using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDesktopUI.Models
{
    public class CartItemDisplayModel : INotifyPropertyChanged
    {
        public ProductDisplayModel Product { get; set; }
        private int _quantityInCart;        

        public int QuantityInCart
        {
            get { return _quantityInCart; }
            set 
            { 
                _quantityInCart = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuantityInCart)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayText)));
            }
        }

        public string DisplayText
        {
            get
            {
                return $"{Product.ProductName} ( {QuantityInCart} )";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
