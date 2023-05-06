using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Librarys.Ui
{
    public class Utilities
    {
        public static void Item_Pager(Repeater rptPager, int totalRows, int currentPage, DataTable dt)
        {
            List<ListItem> pages = new List<ListItem>();
            foreach (DataRow row in dt.Rows)
            {
                int aa = Convert.ToInt32(row["SEQNO"].ToString());
                if (totalRows == 1)
                {
                    pages.Add(new ListItem("CLAIM (" +  row["SEQNO"].ToString() + ")", row["SEQNO"].ToString(), true));
                }
                else
                {
                    if (aa == 0)
                    {
                        pages.Add(new ListItem( "CLAIM (" + row["SEQNO"].ToString() + ")", row["SEQNO"].ToString(), false));
                    }
                    else if (aa == totalRows - 1)
                    {
                        pages.Add(new ListItem("CLAIM (" + row["SEQNO"].ToString() + ")", row["SEQNO"].ToString(), true));
                    }
                    else
                    {
                        pages.Add(new ListItem("CLAIM (" + row["SEQNO"].ToString() + ")", row["SEQNO"].ToString(), false));
                    }
                }
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        public static void PopulatePager(Repeater rpt_Pager, Label r_pageCount, int p_PageSize, int recordCount, int currentPage)
        {
            List<ListItem> pages = new List<ListItem>();
            int startIndex, endIndex;
            int pagerSpan = 5; 
            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(p_PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<i class='fa fa-angle-double-left'></i>", "1"));
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<i class='fa fa-angle-left'></i>", (currentPage - 1).ToString()));
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new ListItem("<i class='fa fa-angle-right'></i>", (currentPage + 1).ToString()));
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("<i class='fa fa-angle-double-right'></i>", pageCount.ToString()));
            }
            rpt_Pager.DataSource = pages;
            rpt_Pager.DataBind();
            r_pageCount.Text = pageCount.ToString();
        }
        public static void PopulatePager(Repeater rptPager, Label r_label, int totalRows, int PageSize, int recordCount, int currentPage)
        {
            List<ListItem> pages = new List<ListItem>();
            int startIndex, endIndex;
            int pagerSpan = 5;
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 10;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }
            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }
            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }
            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<i class='fa fa-angle-double-left'></i>", "1"));
            }
            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<i class='fa fa-angle-left'></i>", (currentPage - 1).ToString()));
            }
            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new ListItem("<i class='fa fa-angle-right'></i>", (currentPage + 1).ToString()));
            }
            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("<i class='fa fa-angle-double-right'></i>", pageCount.ToString()));
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
            r_label.Text = "Trang " + currentPage + " trên " + pageCount.ToString() + " trang của";
        }
        public static void BindDropDownList(DropDownList droplist, DataTable dt, string dataValueField, string dataTextField, int selectedIndex)
        {
            droplist.Items.Clear();
            bool flag = dt != null && dt.Rows.Count > 0;
            if (flag)
            {
                droplist.DataSource = dt;
                droplist.DataValueField = dataValueField;
                droplist.DataTextField = dataTextField;
                droplist.DataBind();
                droplist.SelectedIndex = selectedIndex;
            }
        }
        public static void BindDropDownList(DropDownList droplist, DataTable dt, string dataValueField, string dataTextField, int selectedIndex, string displayTextOther, string keyValue)
        {
            droplist.Items.Clear();
            bool flag = dt != null && dt.Rows.Count > 0;
            if (flag)
            {
                droplist.DataSource = dt;
                droplist.DataValueField = dataValueField;
                droplist.DataTextField = dataTextField;
                droplist.DataBind();
                droplist.SelectedIndex = selectedIndex;
                droplist.Items.Insert(0, new ListItem(displayTextOther, keyValue));
            }
            else
            {
                droplist.Items.Insert(0, new ListItem(displayTextOther, keyValue));
            }
        }
        public static void BindDropDownList<T>(DropDownList droplist, IList<T> list, string dataValueField, string dataTextField, int selectedIndex)
        {
            droplist.Items.Clear();
            bool flag = list != null && list.Any<T>();
            if (flag)
            {
                droplist.DataSource = list;
                droplist.DataValueField = dataValueField;
                droplist.DataTextField = dataTextField;
                droplist.DataBind();
                droplist.SelectedIndex = selectedIndex;
            }
        }
        public static void BindDropDownList<T>(DropDownList droplist, IList<T> list, string dataValueField, string dataTextField, int selectedIndex, string displayTextOther, string keyValue)
        {
            droplist.Items.Clear();
            bool flag = list != null && list.Any<T>();
            if (flag)
            {
                droplist.DataSource = list;
                droplist.DataValueField = dataValueField;
                droplist.DataTextField = dataTextField;
                droplist.DataBind();
                droplist.Items.Insert(0, new ListItem(displayTextOther, keyValue));
                droplist.SelectedIndex = selectedIndex;
            }
            else
            {
                droplist.Items.Insert(0, new ListItem(displayTextOther, keyValue));
            }
        }

    }
}
