/*
 *  Filename:       MainWindow.xaml.cs
 *  Author:         Vivian Ren (301030868)
 *  Due date:       February 8, 2019
 *  Description:    Part of Question 1 for Lab 2 of COMP212.
 *                  Contains interaction logic for MainWindow.xaml.
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
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

namespace _301030868_ren__Question1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ObservableCollection for the list of ordered items to be placed in the data grid.
        ObservableCollection<OrderItems> ordered = new ObservableCollection<OrderItems>();

        // Dictionary for all food items.
        Dictionary<string, double> beverages = new Dictionary<string, double>();
        Dictionary<string, double> appetizers = new Dictionary<string, double>();
        Dictionary<string, double> mainCourses = new Dictionary<string, double>();
        Dictionary<string, double> desserts = new Dictionary<string, double>();
        double subtotal = 0;
        double tax = 0;

        public MainWindow()
        {
            // Fill dictionaries with corresponding orders, with food name as key and its price as value
            beverages.Add("Soda", 1.95 );
            beverages.Add("Tea", 1.50 );
            beverages.Add("Coffee", 1.25 );
            beverages.Add("Mineral Water", 2.95 );
            beverages.Add("Juice", 2.50 );
            beverages.Add("Milk", 1.50 );

            appetizers.Add("Buffalo Wings", 5.95 );
            appetizers.Add("Buffalo Fingers", 6.95 );
            appetizers.Add("Potato Skins", 8.95 );
            appetizers.Add("Nachos",8.95 );
            appetizers.Add("Mushroom Caps", 10.95 );
            appetizers.Add("Shrimp Cocktail", 12.95 );

            mainCourses.Add("Seafood Alfredo", 15.95 );
            mainCourses.Add("Chicken Alfredo", 13.95 );
            mainCourses.Add("Chicken Picatta", 13.95 );
            mainCourses.Add("Turkey Club", 11.95 );
            mainCourses.Add("Lobster Pie", 19.95 );
            mainCourses.Add("Prime Rib", 20.95 );
            mainCourses.Add("Shrimp Scampi", 18.95 );
            mainCourses.Add("Turkey Dinner", 13.95 );
            mainCourses.Add("Stuffed Chicken", 14.95 );

            desserts.Add("Apple Pie", 5.95 );
            desserts.Add("Sundae", 3.95 );
            desserts.Add("Carrot Cake", 5.95 );
            desserts.Add("Mud Pie", 4.95 );
            desserts.Add("Apple Crisp", 5.95 );

            // Convert key values to usable string array to be used for each combobox display
            string[] beverageNames = new string[beverages.Count + 1];
            beverageNames[0] = "";
            beverages.Keys.ToArray().CopyTo(beverageNames, 1);

            string[] appetizerNames = new string[appetizers.Count + 1];
            appetizerNames[0] = "";
            appetizers.Keys.ToArray().CopyTo(appetizerNames, 1);

            string[] mainCourseNames = new string[mainCourses.Count + 1];
            mainCourseNames[0] = "";
            mainCourses.Keys.ToArray().CopyTo(mainCourseNames, 1);

            string[] dessertNames = new string[desserts.Count + 1];
            dessertNames[0] = "";
            desserts.Keys.ToArray().CopyTo(dessertNames, 1);

            InitializeComponent();

            // Add ItemsSource to all Comboboxes
            BeverageComboBox.ItemsSource = beverageNames;
            AppetizerComboBox.ItemsSource = appetizerNames;
            MainCourseComboBox.ItemsSource = mainCourseNames;
            DessertComboBox.ItemsSource = dessertNames;

            // Link DataGrid to the ObservableCollection
            orderList.ItemsSource = ordered;
            UpdateCost();
        }

        /*
         *  Hyperlink_RequestNavigate method
         *  
         *  Used to send a request to navigate to a given URL.
         *  Currently only runs with the image in the status bar that links to the Centennial College website.
         *
         */
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        /*
         * DropDownClosed method
         * 
         * When any combobox drop down is closed (user selects an item), this method is run.
         * Adds the new selection into the DataGrid's ObservableCollection (or combines quantities)
         * and sums up totals.
         * 
         */
        private void DropDownClosed(object sender, EventArgs e)
        {
            string str;

            if (sender == DessertComboBox)
            {
                str = DessertComboBox.SelectedValue.ToString();
            }
            else if (sender == BeverageComboBox)
            {
                str = BeverageComboBox.SelectedValue.ToString();
            }
            else if (sender == AppetizerComboBox)
            {
                str = AppetizerComboBox.SelectedValue.ToString();
            }
            else // sender == MainCourseComboBox
            {
                str = MainCourseComboBox.SelectedValue.ToString();
            }

            if (str != "")
            {

                // Check if the added item is in 
                OrderItems checkOrders = ordered.FirstOrDefault(i => i.Name  == str);

                // The item is already in the Observable collection.
                // Add one on top of the item quantity.
                if (checkOrders != null)
                {
                    // We set max quantity per item to 20.
                    // otherwise AddItemQuantity throws a custom 
                    // TooManyItemsException.
                    try
                    {
                        AddItemQuantity(checkOrders, 1, sender);

                        if (sender == DessertComboBox)
                        {
                            subtotal += desserts[str];
                        }
                        else if (sender == BeverageComboBox)
                        {
                            subtotal += beverages[str];
                        }
                        else if (sender == AppetizerComboBox)
                        {
                            subtotal += appetizers[str];
                        }
                        else if (sender == MainCourseComboBox)
                        {
                            subtotal += mainCourses[str];
                        }

                    } catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    
                }
                // We have a new item added to the ObservableCollection.
                // Add it to the collection, as per its category based on combobox sender.
                else
                {
                    OrderItems item = new OrderItems();
                    if (sender == DessertComboBox)
                    {
                        item = new OrderItems { Name = str, Category = "Dessert", Price = desserts[str]};
                        subtotal += desserts[str];
                    }
                    else if (sender == BeverageComboBox)
                    {
                        item = new OrderItems { Name = str, Category = "Beverage", Price = beverages[str]};
                        subtotal += beverages[str];
                    }
                    else if (sender == AppetizerComboBox)
                    {
                        item = new OrderItems { Name = str, Category = "Appetizer", Price = appetizers[str]};
                        subtotal += appetizers[str];
                    }
                    else if (sender == MainCourseComboBox)
                    {
                        item = new OrderItems { Name = str, Category = "Main Course", Price = mainCourses[str]};
                        subtotal += mainCourses[str];
                    }

                    ordered.Add(item);
                    UpdateCost();
                }
                
            }
        }

        /*
         * AddItemQuantity method
         * 
         * Adds the given item quantity to the selected OrderItems in the ObservableCollection.
         * Changes to the given item quantity instead if the sender is the data grid itself.
         * Updates prices accordingly.
         * 
         * Note that max item quantity is set to 20.
         * 
         */
        private void AddItemQuantity(OrderItems checkOrders, int quantity, Object sender)
        {

            int newQuantity;
            int oldQuantity = checkOrders.Quantity;
            if (sender == orderList)
                 newQuantity = quantity;
            else
                newQuantity = oldQuantity + quantity;
            
            if (newQuantity <= 20)
            {
                OrderItems newOrder = new OrderItems { Name = checkOrders.Name, Category = checkOrders.Category, Price = checkOrders.Price, Quantity = newQuantity };
                subtotal += checkOrders.Price * (newQuantity - oldQuantity);
                var index = ordered.IndexOf(checkOrders);
                ordered[index] = newOrder;
                UpdateCost();
            }
            else
            {
                throw (new TooManyItemsException("Maximum orders for any item is 20 only."));
            }
            
        }

        /*
         * UpdateCost method
         * 
         * Updates all cost textblock elements.
         * 
         */
        private void UpdateCost()
        {
            subtotalText.Text = $"{subtotal:C2}";
            tax = subtotal * 0.15;
            taxText.Text = $"{tax:C2}";
            totalText.Text = $"{subtotal+tax:C2}";
        }

        /*
         * 
         * ClearBtn_Click Method
         * 
         * Runs when the "Clear Bill" button is clicked.
         * Clears the DataGrid and the costs.
         * 
         */
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ordered.Clear();
            subtotal = 0;
            UpdateCost();
        }

        /*
         * 
         * RemoveSelectedBtn_Click Method
         * 
         * Runs when the "Remove Selected" button is clicked.
         * Removes selected item in the data grid from the ObservableCollection.
         * Updates the price accordingly.
         * 
         */
        private void RemoveSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ordered.Count() > 0 && orderList.SelectedIndex > -1)
            {
                subtotal -= ordered[orderList.SelectedIndex].Price * ordered[orderList.SelectedIndex].Quantity;
                ordered.RemoveAt(orderList.SelectedIndex);
                UpdateCost();
            }

        }

        /*
         * 
         * OrderList_CellEditEnding_Click Method
         * 
         * Runs when the Quantity for an item is changed in the Data Grid.
         * (All the other columns are read-only)
         * 
         * Makes sure that the input is actually an int, if not outputs to the user
         * that the input is not int and cancels the edit.
         * 
         * Then it adds the quantity to the given item, updating price accordingly.
         * 
         */
        private void OrderList_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox currentEdit = e.EditingElement as TextBox;

            string quantity = currentEdit.Text;
            OrderItems toChange = ordered[e.Row.GetIndex()];

            try {
                int addQuant = int.Parse(quantity);
                try
                {
                    AddItemQuantity(toChange, addQuant, sender);
                } catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    e.Cancel = true;
                }
            } catch (Exception)
            {
                MessageBox.Show("Please enter an integer value for quantity.");
                e.Cancel = true;
            }
        }
    }

    // Exception Class for when the quantity is too much.
    public class TooManyItemsException : Exception
    {
        public TooManyItemsException(string message) : base(message)
        {
        }
    }
}
