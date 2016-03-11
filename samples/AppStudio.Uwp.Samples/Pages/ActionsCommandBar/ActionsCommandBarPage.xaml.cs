﻿using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Actions;
using System.Collections.Generic;
using Windows.UI.Xaml;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using AppStudio.Uwp.Samples.Extensions;

namespace AppStudio.Uwp.Samples
{
    [SamplePage(Category = "Utilities", Name = "ActionsCommandBar", Order = 20)]
    public sealed partial class ActionsCommandBarPage : SamplePage
    {
        public ActionsCommandBarPage()
        {
            ActionCommands = new List<ActionInfo>();
            ActionCommands.Add(new ActionInfo()
            {
                ActionType = ActionType.Primary,
                Text = "Primary C#",
                Style = ActionKnownStyles.Mail,
                Command = MessageCommand,
                CommandParameter = this.GetResourceString("MessageCommandFromCode")
            });
            ActionCommands.Add(new ActionInfo()
            {
                ActionType = ActionType.Secondary,
                Text = "C#",
                Style = ActionKnownStyles.Phone,
                Command = MessageCommand,
                CommandParameter = this.GetResourceString("MessageCommandFromCode")
            });
            this.InitializeComponent();
            this.DataContext = this;
        }

        #region ActionCommands
        public List<ActionInfo> ActionCommands
        {
            get { return (List<ActionInfo>)GetValue(ActionCommandsProperty); }
            set { SetValue(ActionCommandsProperty, value); }
        }
        public static readonly DependencyProperty ActionCommandsProperty =DependencyProperty.Register("ActionCommands", typeof(List<ActionInfo>), typeof(ActionsCommandBarPage), new PropertyMetadata(null));
        #endregion

        #region MessageCommand        
        public ICommand MessageCommand
        {
            get
            {
                return new RelayCommand<string>(async(message) =>
                {
                    MessageDialog messageDialog = new MessageDialog(message);
                    await messageDialog.ShowAsync();
                });
            }
        }        
        #endregion

        public override string Caption
        {
            get { return "ActionsCommandBar"; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);            
        }
    }
}