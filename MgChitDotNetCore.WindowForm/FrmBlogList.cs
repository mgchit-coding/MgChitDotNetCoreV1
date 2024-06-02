using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Shared;
using MgChitDotNetCore.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MgChitDotNetCore.WindowForm
{
    public partial class FrmBlogList : Form
    {
        private readonly AppDbContext _context;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _context = new AppDbContext();
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new AppDbContext())
            {
                var id = dgvData.Rows[e.RowIndex].Cells["colID"].Value.ToInt();
                var blog = context.Blog.FirstOrDefault(x => x.BlogId == id);
                if (e.ColumnIndex == (int)EnumFormType.Edit)
                {
                    FrmBlog frmBlog = new FrmBlog(id);
                    frmBlog.ShowDialog();
                    BlogList();
                }
                else if (e.ColumnIndex == (int)EnumFormType.Delete)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult != DialogResult.Yes) return;

                    context.Blog.Remove(blog);
                    context.SaveChangesAsync();
                    BlogList();
                }
            }
        }

        private void BlogList()
        {
            using(var context = new AppDbContext())
            {
                var blog = context.Blog.ToList();
                dgvData.DataSource = blog.Select(x => new BlogViewModel
                {
                    ID = x.BlogId,
                    Title = x.BlogTitle,
                    Author = x.BlogAuthor,
                    Content = x.BlogContent,
                }).ToList();
            }
        }
    }
}
