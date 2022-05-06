﻿using FluentTerminal.Models;
using GalaSoft.MvvmLight;

namespace FluentTerminal.App.ViewModels.Menu
{
    public class MenuItemViewModelBase : ViewModelBase
    {
        #region Properties

        private string _text;

        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        private string _description;

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        private Mdl2Icon _icon;

        public Mdl2Icon Icon
        {
            get => _icon;
            set => Set(ref _icon, value);
        }

        #endregion Properties

        #region Constructor

        protected MenuItemViewModelBase(string text, string description, Mdl2Icon icon)
        {
            _text = text;
            _description = description;
            _icon = icon;
        }

        #endregion Constructor

        #region Methods

        public virtual bool EquivalentTo(MenuItemViewModelBase other)
        {
            if (ReferenceEquals(this, other)) return true;

            if (other == null) return false;

            return _text.NullableEqualTo(other._text) && _description.NullableEqualTo(other._description) &&
                   (_icon?.Equals(other._icon) ?? other._icon == null);
        }

        #endregion Methods
    }
}