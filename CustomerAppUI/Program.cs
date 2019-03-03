using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using System;
using System.Collections.Generic;


namespace CustomerAppUI
{
    class Program
    {
        //The access point from UI to BLL service...
        static BLLFacade bllFacade = new BLLFacade();


        static void Main(string[] args)
        {
            // First way of creating an object
            CustomerBO cust1 = new CustomerBO()
            {
                FirstName = "Arsen",
                LastName = "Tabaku",
                Address = "Berat"
            };
            bllFacade.CustomerService.Create(cust1);
            

            // Second way of creating an object
            CustomerBO cust2 = new CustomerBO();
            cust2.FirstName = "Visar";
            cust2.LastName = "Mance";
            cust2.Address = "Tirane";
            bllFacade.CustomerService.Create(cust2);


            /* Third way of creating an object
            bllFacade.CustomerService.Create(new Customer()
            {
                FirstName = "Arsen",
                LastName = "Tabaku",
                Address = "Berat"
            }); */



            string[] menuItems =
            {
                "List All Costumers",
                "Add Costumer",
                "Delete Costumer",
                "Edit Costumer",
                "Exit"
            };

            var selection = ShowMenu(menuItems);
            while (true)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomer();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        EditCustomer();
                        break;
                    default:
                        Console.WriteLine("Tchüssss!");
                        break;
                }

                selection = ShowMenu(menuItems);
            }

            Console.ReadLine();
        }





        private static void ListCustomers()
        {
            List<CustomerBO> customers = bllFacade.CustomerService.GetAll();
            foreach (var c in customers)
            {
                /*OLD WAY - Before adding the property full name on CustomerBO
                 * Console.WriteLine("ID: " + c.Id + "  |  Full Name: " + c.FirstName + " " + c.LastName + "  |   Address: " + c.Address);
                 */
                Console.WriteLine($"Id:{c.Id} Name: {c.FullName} Address:{c.Address}");
            }
        }

        
        //Edit function
        private static void EditCustomer()
        {
            var customer = FindCustomerById();
            if(customer!=null)
            {
                Console.WriteLine("First name: ");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("Last name: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                customer.Address = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }
            bllFacade.CustomerService.Update(customer);
        }

        
        //Find customer
        private static CustomerBO FindCustomerById()
        {
            Console.WriteLine("Insert customer id:");
            int idDelete = 0;
            while (!int.TryParse(Console.ReadLine(), out idDelete))
            {
                Console.WriteLine("Please insert a number!!!");
            }
            return bllFacade.CustomerService.Get(idDelete);
        }


        //Delete customer
        private static void DeleteCustomer()
        {
            var customerFound = FindCustomerById();
            if (customerFound != null)
            {
                bllFacade.CustomerService.Delete(customerFound.Id);
                Console.WriteLine("Customer was deleted!");
            }
            else
                Console.WriteLine("Customer not found!");
            
            /*SECOND WAY - TERTIARY OPERATOR
             var response = ((customerFound != null) ? "Customer was deleted!" : "Customer not found!");
            Console.WriteLine(response);
             */
        }


        //Add customer
        private static void AddCustomer()
        {
            Console.WriteLine("First name: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            var address = Console.ReadLine();

            bllFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            });
        }

       

        //Show menu
        private static int ShowMenu(string[] menuItems)
        {
            //Console.Clear();

            Console.WriteLine("What do you want to do: \n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
                //Console.WriteLine((i + 1) + ". " + menuItems[i]);
            }
            Console.WriteLine("");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1 || selection > 5)
            {
                Console.WriteLine("\nYou need a number between 1-5:");
            }

            Console.WriteLine("You selected: " + selection);
            Console.WriteLine("");

            return selection;

        }
    }
}
