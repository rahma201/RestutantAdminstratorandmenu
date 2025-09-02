﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pro2.Models;

public partial class Pro2Context : IdentityDbContext
{
    

    public Pro2Context(DbContextOptions<Pro2Context> options): base(options)
    {
    }


    public virtual DbSet<MasterCategoryMenu> MasterCategoryMenus { get; set; }

    public virtual DbSet<MasterContactUsInformation> MasterContactUsInformations { get; set; }

    public virtual DbSet<MasterItemMenu> MasterItemMenus { get; set; }

    public virtual DbSet<MasterMenu> MasterMenus { get; set; }

    public virtual DbSet<MasterOffer> MasterOffers { get; set; }

    public virtual DbSet<MasterPartner> MasterPartners { get; set; }

    public virtual DbSet<MasterService> MasterServices { get; set; }

    public virtual DbSet<MasterSlider> MasterSliders { get; set; }

    public virtual DbSet<MasterSocialMedium> MasterSocialMedia { get; set; }

    public virtual DbSet<MasterWorkingHour> MasterWorkingHours { get; set; }

    public virtual DbSet<SystemSetting> SystemSettings { get; set; }

    public virtual DbSet<TransactionBookTable> TransactionBookTables { get; set; }

    public virtual DbSet<TransactionContactUViewModel> TransactionContactUs { get; set; }

    public virtual DbSet<TransactionNewsletter> TransactionNewsletters { get; set; }


}
