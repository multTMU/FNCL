using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets.FilterOrder
{
    public partial class FilterOrdering : UserControl
    {
        public List<AppliedPulseFilters> PulseFilterOrder => GetPulseFiltersToUse();

        private struct PulseFilterState
        {
            public AppliedPulseFilters Filter;
            public bool Apply;

            public PulseFilterState(AppliedPulseFilters filter)
            {
                Filter = filter;
                Apply = true;
            }

            public void SetDoNotApplyFilter()
            {
                Apply = false;
            }

            public void SetApplyFilter()
            {
                Apply = true;
            }
        }

        private PulseFilterState[] pulseFilterOrder;
        private int currentSelected;
        private int nFilters;
        private const string DO_NOT_APPLY = "NO ";
        private bool hasFilters;

        public FilterOrdering()
        {
            InitializeComponent();
        }

        private List<AppliedPulseFilters> GetPulseFiltersToUse()
        {
            List<AppliedPulseFilters> filters = new List<AppliedPulseFilters>();
            foreach (var f in pulseFilterOrder)
            {
                if (f.Apply)
                {
                    filters.Add(f.Filter);
                }
            }

            return filters;
        }

        public void SetDefaultFilterOrder(List<AppliedPulseFilters> defaultOrder)
        {
            nFilters = defaultOrder.Count;
            hasFilters = nFilters > 0;
            pulseFilterOrder = new PulseFilterState[nFilters];
            for (int i = 0; i < nFilters; i++)
            {
                pulseFilterOrder[i] = new PulseFilterState(defaultOrder[i]);
            }

            this.dataGridView1.Columns.Add("Filter", "Filter");
            if (hasFilters)
            {
                UpdateDisplayedOrder();
            }
        }

        private void SetAll(bool applyState)
        {
            for (int i = 0; i < pulseFilterOrder.Length; i++)
            {
                if (applyState)
                {
                    pulseFilterOrder[i].SetApplyFilter();
                }
                else
                {
                    pulseFilterOrder[i].SetDoNotApplyFilter();
                }
            }
        }

        private void UpdateDisplayedOrder()
        {
            this.dataGridView1.Rows.Clear();
            foreach (var f in pulseFilterOrder)
            {
                string preFix = (f.Apply ? "" : DO_NOT_APPLY);
                this.dataGridView1.Rows.Add(preFix + f.Filter.ToString());
            }

            this.dataGridView1.Rows[currentSelected].Selected = true;
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            if (hasFilters)
            {
                UpArrow();
            }
        }

        private void UpArrow()
        {
            UpdateCurrentIndex();
            int swapIndex = currentSelected - 1;
            if (swapIndex < 0)
            {
                swapIndex = nFilters - 1;
            }

            Swap(swapIndex);
        }

        private void Swap(int swapIndex)
        {
            PulseFilterState current = pulseFilterOrder[currentSelected];
            PulseFilterState swap = pulseFilterOrder[swapIndex];
            pulseFilterOrder[currentSelected] = swap;
            pulseFilterOrder[swapIndex] = current;
            this.dataGridView1.Rows[currentSelected].Selected = false;
            currentSelected = swapIndex;
            UpdateDisplayedOrder();
        }

        private void UpdateCurrentIndex()
        {
            currentSelected = this.dataGridView1.SelectedRows[0].Index;
        }

        private void DownArrow()
        {
            UpdateCurrentIndex();
            int swapIndex = currentSelected + 1;
            if (swapIndex >= nFilters)
            {
                swapIndex = 0;
            }

            Swap(swapIndex);
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            if (hasFilters)
            {
                DownArrow();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (hasFilters)
            {
                if (e.KeyChar == (char)Keys.Up)
                {
                    UpArrow();
                }

                if (e.KeyChar == (char)Keys.Down)
                {
                    DownArrow();
                }
            }
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            if (hasFilters)
            {
                UpdateCurrentIndex();
                pulseFilterOrder[currentSelected].SetDoNotApplyFilter();
                UpdateDisplayedOrder();
            }
        }

        private void bRestore_Click(object sender, EventArgs e)
        {
            if (hasFilters)
            {
                UpdateCurrentIndex();
                pulseFilterOrder[currentSelected].SetApplyFilter();
                UpdateDisplayedOrder();
            }
        }

        private void bRemoveAll_Click(object sender, EventArgs e)
        {
            if (hasFilters)
            {
                SetAll(false);
                UpdateDisplayedOrder();
            }
        }

        private void bRestoreAll_Click(object sender, EventArgs e)
        {
            if (hasFilters)
            {
                SetAll(true);
                UpdateDisplayedOrder();
            }
        }
    }
}
