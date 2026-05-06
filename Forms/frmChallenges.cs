using Delve;
using DelveCS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DelveCS.Forms{
 public partial class frmChallenges:Form{
  public frmChallenges(){
   InitializeComponent();
  }
  private void btnOk_Click(object sender,EventArgs e){
   this.Close();
  }
  private void frmChallenges_Load(object sender,EventArgs e){
   int i=0;
   Listitem? item=null;
   Challenge.LoadChallenges();
   Challenge.Catalogue.ForEach(challenge=>{
    item=new Listitem(challenge.Name,challenge.Description);
    chkLstChallenges.Items.Add(item);
    chkLstChallenges.SetItemChecked(i,challenge.Completed);
    i++;
   });
   Challenge.SaveChallenges();
  }
  private void chkLstChallenges_Click(object sender,EventArgs e){
   CheckedListBox ckl=sender as CheckedListBox;
   Listitem it=ckl.SelectedItem as Listitem;
   txtDescription.Text=it.description;
  }
 }
}