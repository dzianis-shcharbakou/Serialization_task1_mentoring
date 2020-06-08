using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using Task.DB;

namespace Task.TestHelpers
{
    public class OrderDataContractSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            if (typeof(Order).IsAssignableFrom(type))
            {
                return typeof(Order);
            }
            if (typeof(Customer).IsAssignableFrom(type))
            {
                return typeof(Customer);
            }
            if (typeof(Employee).IsAssignableFrom(type))
            {
                return typeof(Employee);
            }
            if (typeof(Order_Detail).IsAssignableFrom(type))
            {
                return typeof(Order_Detail);
            }
            if (typeof(Shipper).IsAssignableFrom(type))
            {
                return typeof(Shipper);
            }

            return type;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (typeof(Order) == targetType)
            {
                Order order = (Order)obj;

                return new Order()
                {
                    CustomerID = order.CustomerID,
                    EmployeeID = order.EmployeeID,
                    Freight = order.Freight,
                    OrderDate = order.OrderDate,
                    OrderID = order.OrderID,
                    RequiredDate = order.RequiredDate,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipCountry = order.ShipCountry,
                    ShipName = order.ShipName,
                    ShippedDate = order.ShippedDate,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipRegion = order.ShipRegion,
                    ShipVia = order.ShipVia,
                    Customer = order.Customer,
                    Employee = order.Employee,
                    Shipper = order.Shipper,
                    Order_Details = order.Order_Details
                };
            }
            if (typeof(Customer) == targetType)
            {
                Customer customer = (Customer)obj;

                return new Customer()
                {
                    CustomerID = customer.CustomerID,
                    Address = customer.Address,
                    City = customer.City,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Country = customer.Country,
                    CustomerDemographics = null,
                    Fax = customer.Fax,
                    Orders = null,
                    Phone = customer.Phone,
                    PostalCode = customer.PostalCode,
                    Region = customer.Region
                };
            }
            if (typeof(Employee) == targetType)
            {
                Employee employee = (Employee)obj;

                return new Employee()
                {
                    Address = employee.Address,
                    Region = employee.Region,
                    PostalCode = employee.PostalCode,
                    HireDate = employee.HireDate,
                    Orders = null,
                    BirthDate = employee.BirthDate,
                    City = employee.City,
                    Country = employee.Country,
                    EmployeeID = employee.EmployeeID,
                    Employee1 = null,
                    Employees1 = null,
                    Extension = employee.Extension,
                    FirstName = employee.FirstName,
                    HomePhone = employee.HomePhone,
                    LastName = employee.LastName,
                    Notes = employee.Notes,
                    Photo = employee.Photo,
                    PhotoPath = employee.PhotoPath,
                    ReportsTo = employee.ReportsTo,
                    Territories = null,
                    Title = employee.Title,
                    TitleOfCourtesy = employee.TitleOfCourtesy
                };
            }
            if (typeof(Order_Detail) == targetType)
            {
                Order_Detail order_detail = (Order_Detail)obj;

                return new Order_Detail()
                {
                    Discount = order_detail.Discount,
                    Order = null,
                    OrderID = order_detail.OrderID,
                    Product = null,
                    ProductID = order_detail.ProductID,
                    Quantity = order_detail.Quantity,
                    UnitPrice = order_detail.UnitPrice
                };

            }
            if (typeof(Shipper) == targetType)
            {
                Shipper shiper = (Shipper)obj;

                return new Shipper()
                {
                    CompanyName = shiper.CompanyName,
                    Orders = null,
                    Phone = shiper.Phone,
                    ShipperID = shiper.ShipperID
                };
            }

            return obj;
        }

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }
    }
}
