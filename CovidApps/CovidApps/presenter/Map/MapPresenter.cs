using CovidApps.contract;
using CovidApps.contract.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.presenter.Map
{
    public class MapPresenter : IPresenter, IOnListerner
    {
        IView mainView; 
        IModel mainModel; 
        public MapPresenter(IView view, IModel model) 
        { 
            this.mainView = view; 
            this.mainModel = model; 
        }
        public void getCurrentLocation()
        {
            if (this.mainModel != null) 
                this.mainModel.getCurrentLocation(this);
        }

        public void OnFailure(string error)
        {
            if (this.mainView != null)
                this.mainView.OnFailure(error);
        }

        public void onGetCurrentLocationSuccess(LocationInfo locationInfo)
        {
            if (this.mainView != null) 
                this.mainView.onGetCurrentLocationSuccess(locationInfo);
        }
    }
}
