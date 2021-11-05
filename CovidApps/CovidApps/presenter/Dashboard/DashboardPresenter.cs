using CovidApps.contract;
using CovidApps.contract.DashboardPage;
using CovidApps.database;
using CovidApps.json.covid19;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.presenter.Dashboard
{
    public class DashboardPresenter : IPresenter, IOnListerner
    {
        IView mainView;
        IModel mainModel; 
        public DashboardPresenter(IView view, IModel model) 
        { 
            this.mainView = view; 
            this.mainModel = model;
        }
        public void getCovidRecord()
        {
            if (this.mainModel != null) 
                this.mainModel.getCovidRecord(this);
        }

        public void OnGetRecordSuccess(List<JsonCovidRecord> covidRecords)
        {
            if (this.mainView != null) 
                this.mainView.OnGetRecordSuccess(covidRecords);
        }
    }
}
