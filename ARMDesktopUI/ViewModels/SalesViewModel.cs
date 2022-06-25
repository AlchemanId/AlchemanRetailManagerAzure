﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set 
            { 
                _products = value; 
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set 
            { 
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set 
            { 
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public string SubTotal 
        {
            get
            {
                return "0.00"; 
            }
        }
        public string Tax
        {
            get
            {
                return "0.00";
            }
        }
        public string STotal
        {
            get
            {
                return "0.00";
            }
        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                // Make sure something is selected
                // make sure there is an item quantity
                return output;
            }
        }
        public void AddToCart()
        {

        }
        public bool CanRemoveToCart
        {
            get
            {
                bool output = false;
                // Make sure something is selected
                return output;
            }
        }
        public void RemoveToCart()
        {

        }
        public bool CanCheckOut
        {
            get
            {
                bool output = false;
                // Make sure something in the cart
                return output;
            }
        }
        public void CheckOut()
        {

        }

    }
}
