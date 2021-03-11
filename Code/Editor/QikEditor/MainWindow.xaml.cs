﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock.Layout;

namespace QikEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            layoutRoot.ElementAdded += LayoutRoot_ElementAdded;
            layoutRoot.ElementRemoved += LayoutRoot_ElementRemoved;

            DockManager.DocumentClosing += (s, e) => AddEvent($"{e.Document.ContentId} closing");
            DockManager.DocumentClosed += (s, e) => { };
        }

        private void LayoutRoot_ElementRemoved(object sender, LayoutElementEventArgs e)
        {
            if (e.Element is LayoutDocument)
                AddEvent($"{(e.Element as LayoutDocument).ContentId} removed");
        }

        private void LayoutRoot_ElementAdded(object sender, LayoutElementEventArgs e)
        {
            if (e.Element is LayoutDocumentFloatingWindow)
            {
                //AddEvent($"{(e.Element as LayoutDocumentFloatingWindow).RootDocument.Title} added");
            }
            else if (e.Element is LayoutDocument)
            {
                AddEvent($"{(e.Element as LayoutDocument).ContentId} added");
            }
        }

        private void AddEvent(string eventText)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = eventText;
            ListBoxItem listBoxItem = new ListBoxItem();
            listBoxItem.Content = textBlock;

            EventsListBox.Items.Add(listBoxItem);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string id = Guid.NewGuid().ToString();

            LayoutDocument document = new LayoutDocument() { ContentId = id, Title = $"Document: [{id}]", IsSelected = true };
            document.IsSelectedChanged += Document_IsSelectedChanged;
            document.IsActiveChanged += Document_IsActiveChanged;
            DocumentArea.Children.Add(document);


        }

        private void Document_IsActiveChanged(object sender, EventArgs e)
        {
            LayoutDocument document = sender as LayoutDocument;
            if (document.IsActive)
            {
                AddEvent($"{ document.ContentId} activated");
                ActiveDocumentStatus.Text = layoutRoot.LastFocusedDocument.Title;
            }
        }

        private void Document_IsSelectedChanged(object sender, EventArgs e)
        {
            LayoutDocument document = sender as LayoutDocument;
            if (document.IsSelected)
            {
                AddEvent($"{ document.ContentId} selected");
                ActiveDocumentStatus.Text = layoutRoot.LastFocusedDocument.Title;
            }
        }
    }
}
