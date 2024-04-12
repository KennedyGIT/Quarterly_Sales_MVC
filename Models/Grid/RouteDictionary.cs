﻿using QuarterlySalesApp.Models.DTOs;
using QuarterlySalesApp.Models.ExtensionMethods;
using System.Diagnostics;

namespace QuarterlySalesApp.Models.Grid
{
    public static class FilterPrefix
    {
        public const string Employee = "employee-";
    }
    public class RouteDictionary : Dictionary<string, string>
    {
        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) &&
                current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public string EmployeeFilter
        {
            get => Get(nameof(SalesGridDTO.Employee))?.Replace(FilterPrefix.Employee, "");
            set => this[nameof(SalesGridDTO.Employee)] = value;
        }

        public void ClearFilters() =>
             EmployeeFilter = SalesGridDTO.DefaultFilter;

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;



        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}
