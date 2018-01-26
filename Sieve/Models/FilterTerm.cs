﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sieve.Models
{
    public class FilterTerm
    {
        public string Name { get; set; }

        public string Operator { get; set; }

        [BindNever]
        public FilterOperator OperatorParsed {
            get {
                switch (Operator.Trim().ToLower())
                {
                    case "equals":
                    case "eq":
                    case "==":
                        return FilterOperator.Equals;
                    case "lessthan":
                    case "lt":
                    case "<":
                        return FilterOperator.LessThan;
                    case "greaterthan":
                    case "gt":
                    case ">":
                        return FilterOperator.GreaterThan;
                    case "greaterthanorequalto":
                    case "gte":
                    case ">=":
                        return FilterOperator.GreaterThanOrEqualTo;
                    case "lessthanorequalto":
                    case "lte":
                    case "<=":
                        return FilterOperator.LessThanOrEqualTo;
                    case "contains":
                    case "co":
                    case "@=":
                        return FilterOperator.Contains;
                    case "startswith":
                    case "sw":
                    case "_=":
                        return FilterOperator.StartsWith;
                    default:
                        return FilterOperator.Equals;
                }
            }
        }

        public string Value { get; set; }

        public bool Descending { get; set; } = false;
    }
}