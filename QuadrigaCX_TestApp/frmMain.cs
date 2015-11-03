﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuadrigaCX;

namespace QuadrigaCX_TestApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCurrentTradingInfo_Click(object sender, EventArgs e)
        {
            QuadrigaAPI api = new QuadrigaAPI();
            try
            {
                var tradinginfo = api.GetCurrentTradingInformation(txtOrderBook.Text, chkUseLocalTime.Checked);
                frmObjectVisualizer frm = new frmObjectVisualizer(tradinginfo);
                frm.Show();
            }
            catch (QuadrigaResultError ex)
            {
                MessageBox.Show(String.Format("Code: {0}, Message: {1}", ex.QuadrigaErrorCode, ex.Message));
            }

        }
        private void btnOrderBook_Click(object sender, EventArgs e)
        {
            QuadrigaAPI api = new QuadrigaAPI();
            try
            {
                var orderbook = api.GetOrderBook(txtOrderBook.Text,chkGroup.Checked,chkUseLocalTime.Checked);
                frmObjectVisualizer frm = new frmObjectVisualizer(orderbook);
                frm.Show();
            }
            catch (QuadrigaResultError ex)
            {
                MessageBox.Show(String.Format("Code: {0}, Message: {1}", ex.QuadrigaErrorCode, ex.Message));
            }
        }
        private void btnTransactions_Click(object sender, EventArgs e)
        {
            QuadrigaAPI api = new QuadrigaAPI();
            try
            {
                var transactions = api.GetTransactions(txtOrderBook.Text, txtTimeFrame.Text,chkUseLocalTime.Checked);
                frmObjectVisualizer frm = new frmObjectVisualizer(transactions);
                frm.Show();
            }
            catch (QuadrigaResultError ex)
            {
                MessageBox.Show(String.Format("Code: {0}, Message: {1}", ex.QuadrigaErrorCode, ex.Message));
            }
        }

        private void btnGetAccountBalance_Click(object sender, EventArgs e)
        {
            QuadrigaAPI api = new QuadrigaAPI(Convert.ToInt32(txtClientID.Text),txtAPIKey.Text,txtAPISecret.Text);
            try
            {
                var output = api.GetAccountBalance();
                frmObjectVisualizer frm = new frmObjectVisualizer(output);
                frm.Show();
            }
            catch (QuadrigaResultError ex)
            {
                MessageBox.Show(String.Format("Code: {0}, Message: {1}", ex.QuadrigaErrorCode, ex.Message));
            }
        }

        private void btnUserTransactions_Click(object sender, EventArgs e)
        {
            QuadrigaAPI api = new QuadrigaAPI(Convert.ToInt32(txtClientID.Text), txtAPIKey.Text, txtAPISecret.Text);
            try
            {
                var transactions = api.GetUserTransactions(Convert.ToInt32(txtOffset.Text),Convert.ToInt32(txtLimit.Text),txtSort.Text,txtOrderBook.Text);
                frmObjectVisualizer frm = new frmObjectVisualizer(transactions);
                frm.Show();
            }
            catch (QuadrigaResultError ex)
            {
                MessageBox.Show(String.Format("Code: {0}, Message: {1}", ex.QuadrigaErrorCode, ex.Message));
            }
        }

        private void btnOpenOrders_Click(object sender, EventArgs e)
        {
            QuadrigaAPI api = new QuadrigaAPI(Convert.ToInt32(txtClientID.Text), txtAPIKey.Text, txtAPISecret.Text);
            try
            {
                var orders = api.GetOpenOrders(txtOrderBook.Text);
                frmObjectVisualizer frm = new frmObjectVisualizer(orders);
                frm.Show();
            }
            catch (QuadrigaResultError ex)
            {
                MessageBox.Show(String.Format("Code: {0}, Message: {1}", ex.QuadrigaErrorCode, ex.Message));
            }
        }




    }
}
