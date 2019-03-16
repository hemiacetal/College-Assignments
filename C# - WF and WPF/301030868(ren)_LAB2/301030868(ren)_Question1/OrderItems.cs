/*
 *  Filename:       OrderItems.cs
 *  Author:         Vivian Ren (301030868)
 *  Due date:       February 8, 2019
 *  Description:    Part of Question 1 for Lab 2 of COMP212.
 *                  Contains the OrderItems object to be used to list all of the
 *                  item information.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301030868_ren__Question1
{
    class OrderItems
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
