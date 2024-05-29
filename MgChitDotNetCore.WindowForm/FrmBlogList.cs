using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Shared.Services;
using Microsoft.EntityFrameworkCore;
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
            var blog = _context.Blog.ToList();
            dgvData.DataSource = blog.Select(x=> new BlogViewModel
            {
                Id = x.BlogId,
                Title = x.BlogTitle,
                Author = x.BlogAuthor,
                Content = x.BlogContent,
            }).ToList();
        }
    }
}
