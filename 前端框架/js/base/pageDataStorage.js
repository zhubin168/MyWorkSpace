!(function () {
    "use strict";

    // 默认选项
    function getDefaultOption() {
        return {
            // 返回需要存储的数据
            getStorageData: null,
            // 恢复存储数据
            restoreStorageData: null
        };
    }

    // 默认数据
    function getDefaultData() {
        return {
            scrollTop: 0,
            data: [],
            pageIndex: 1
        };
    }

    function JhbDataStorage() {
        // 当前页面路径
        this.path = window.location.pathname.toLowerCase();

        // 存储数据
        this.storageData = getDefaultData();
        this.options = getDefaultOption();
        this.enableSaveData = true;
    }

    // 初始化数据存储，返回是否有存储数据
    JhbDataStorage.prototype.init = function (options) {
        var self = this;
        this.options.getStorageData = options.getStorageData;
        this.options.restoreStorageData = options.restoreStorageData;
        var savedData = this.getItem();
        var hasData = savedData !== null
            && savedData.data
            && savedData.data.length
            && savedData.scrollTop;

        // 页面显示事件
        window.addEventListener('pageshow', function () {
            if (hasData) {
                jhbDataStorage.restore(savedData);
            }
        });

        // 页面隐藏事件
        window.addEventListener('pagehide', function () {                        
            /*!jhbGlobal.debug && */jhbDataStorage.pageHide();            
        });

        return hasData;
    }

    JhbDataStorage.prototype.setItem = function (data) {
        window.sessionStorage.setItem(this.path, JSON.stringify(data));
    }

    JhbDataStorage.prototype.removeItem = function (key) {
        window.sessionStorage.removeItem(key);
    }

    JhbDataStorage.prototype.getItem = function () {
        var data = window.sessionStorage.getItem(this.path);

        if (data) {
            try {
                return JSON.parse(data);
            }
            catch(e){
                return null;
            }
        }

        return null;
    }

    // 保存当前页面数据：
    // data：数据
    // pageIndex：当前加载的页码
    JhbDataStorage.prototype.saveData = function (data) {
        var scrollTop = document.documentElement.scrollTop;

        this.storageData.scrollTop = scrollTop;
        this.storageData.data = data.data;
        this.storageData.pageIndex = data.pageIndex;

        this.setItem(this.storageData);
    }

    JhbDataStorage.prototype.restore = function (savedData) {
        savedData
            && savedData.data
            && this.options.restoreStorageData
            && this.options.restoreStorageData(savedData);

        this.removeItem(this.path);
    }

    /**
     * 离开页面保存数据
     */
    JhbDataStorage.prototype.pageHide = function () {        
        if (!this.enableSaveData) {
            return;
        }

        this.removeItem(this.path);

        var data = null;

        if (this.options && this.options.getStorageData) {
            data = this.options.getStorageData();
        }
        
        this.saveData(data);
    }

    /**
     * 禁用保存数据
     */
    JhbDataStorage.prototype.disableSaveData = function () {
        this.enableSaveData = false;
    }

    window.jhbDataStorage = new JhbDataStorage();
})();