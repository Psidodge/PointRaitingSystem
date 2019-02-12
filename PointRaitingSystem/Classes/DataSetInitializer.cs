﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointRaitingSystem
{
    public static class DataSetInitializer<T>
    {
        public static void ComboBoxDataSetInitializer(ref ComboBox elementRef, List<T> dataSet, string valueMember, string displayMember)
        {
            elementRef.DataSource = dataSet;
            elementRef.ValueMember = valueMember;
            elementRef.DisplayMember = displayMember;
        }
        public static void dgvDataSetInitializer(ref DataGridView elementRef, List<T> dataSet, int[] columnsToHide, int[] columnsSizeFill, bool autoGenerateColumns = true)
        {
            elementRef.AutoGenerateColumns = autoGenerateColumns;
            elementRef.DataSource = dataSet;

            if (columnsToHide != null)
                foreach (int index in columnsToHide)
                    elementRef.Columns[index].Visible = false;

            if (columnsSizeFill != null)
                foreach (int index in columnsSizeFill)
                    elementRef.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public static void dgvDataSetInitializer(ref DataGridView elementRef, List<T> dataSet, int[] columnsToHide, string[] columnsSizeFill, bool autoGenerateColumns = true)
        {
            elementRef.AutoGenerateColumns = autoGenerateColumns;
            elementRef.DataSource = dataSet;

            if(columnsToHide != null)
                foreach (int index in columnsToHide)
                    elementRef.Columns[index].Visible = false;

            if(columnsSizeFill != null)
                foreach (string index in columnsSizeFill)
                    elementRef.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public static void dgvDataSetInitializer(ref DataGridView elementRef, List<T> dataSet, bool autoGenerateColumns = true)
        {
            elementRef.AutoGenerateColumns = autoGenerateColumns;
            elementRef.DataSource = dataSet;
        }
        public static void clbDataSetInitialize(ref CheckedListBox elementRef, List<T> dataSource, string valueMember, string displayMember)
        {
            (elementRef as ListBox).DataSource = dataSource;
            (elementRef as ListBox).ValueMember = valueMember;
            (elementRef as ListBox).DisplayMember = displayMember;
        }
        public static void lbDataSetInitialize(ref ListBox elementRef, List<T> dataSource, string valueMember, string displayMember)
        {
            elementRef.DataSource = dataSource;
            elementRef.ValueMember = valueMember;
            elementRef.DisplayMember = displayMember;
        }
    }
}
