﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HappyPocket.Form.Validation;

namespace HappyPocket.DataModel
{
    public class Expense : PropertyChangedNotification
    {
        public int Id
        {
            get => GetValue(() => Id);
            set => SetValue(() => Id, value);
        }
        [MaxLength(40)]
        [Required]
        public string Name
        {
            get => GetValue(() => Name);
            set => SetValue(() => Name, value);
        }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Допустимы только неотрицательные числа.")]
        public int Sum
        {
            get => GetValue(() => Sum);
            set => SetValue(() => Sum, value);
        }

        [DataType(DataType.DateTime)]
        public System.DateTime DateTime
        {
            get => GetValue(() => DateTime);
            set => SetValue(() => DateTime, value);
        }

        // Connection 1-M with FamilyMembers.
        [Required]
        public int FamilyMemberId
        {
            get => GetValue(() => FamilyMemberId);
            set => SetValue(() => FamilyMemberId, value);
        }
        public virtual FamilyMember FamilyMember { get; set; }

        // Connection 1-M with Counteragents.
        [Required]
        public int CounteragentId
        {
            get => GetValue(() => CounteragentId);
            set => SetValue(() => CounteragentId, value);
        }
        public virtual Counteragent Counteragent { get; set; }

        // Connection 1-M with ExpenseCategories.
        [Required]
        public int ExpenseCategoryId
        {
            get => GetValue(() => ExpenseCategoryId);
            set => SetValue(() => ExpenseCategoryId, value);
        }
        public virtual ExpenseCategory ExpenseCategory { get; set; }

        // Connection 1-M with PaymentTypes.
        [Required]
        public int PaymentTypeId
        {
            get => GetValue(() => PaymentTypeId);
            set => SetValue(() => PaymentTypeId, value);
        }
        public virtual PaymentType PaymentType { get; set; }
        // Custom collection that stores instances of PaymentType assigned to this Expense.
        //public virtual ICollection<PaymentType> PaymentTypes { get; set; }
        public Expense()
        {
            Name = "Расход";
            Sum = 0;
            DateTime = System.DateTime.Today;
            FamilyMemberId = 1;
            CounteragentId = 1;
            ExpenseCategoryId = 1;
            PaymentTypeId = 1;
        }
    }
}
