import React, { Component } from 'react';


export class ContentLimitCalc extends Component {
    static displayName = ContentLimitCalc.name;

    constructor(props) {
        super(props);
        this.state = { text: "", viewModel: null, loading: true };
        //this.handleSubmit = this.handleSubmit.bind(this);
    }

    static handleSubmit() {
        var formData = new FormData();

        fetch('ContentsList/addnew', {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                itemName: this.itemname.value,
                itemValue: this.itemvalue.value,
                itemCategory: this.itemcategory.value
            }),
        }).then(response => response.text())
            .then(formData => {
                this.setState({ text: formData, loading: false });
            });

        window.location.reload(true);
    }

    static deleteItem(itemId) {
        fetch('ContentsList/' + itemId, {
            method: 'delete'
        });
        {
            window.location.reload(true);
        }
    }

    componentDidMount() {
        this.populateContentsList();
    }

    static renderContentTable(contentsList, categories) {
        return (
            <>
                <div>{ContentLimitCalc.renderCategoryContents(contentsList)}</div>
                <div>{ContentLimitCalc.renderAddForm(categories)}</div>
            </>
        );
    }

    static renderCategoryContents(contentsList) {
        return (
            contentsList.map((category) =>
                <div id="content_div" key={category.categoryName}>
                    <table id="content_table" aria-labelledby="tableLabel">
                        <tbody id="category_heading">
                            <tr>
                                <td id="contents_text_value" ><h3>{category.categoryName}</h3></td>
                                <td id="contents_numeric_value" ><h3>${category.totalValue}</h3></td>
                            </tr>
                        </tbody>
                        <tr>
                            <td>
                                {ContentLimitCalc.renderContentDetails(category)}
                           </td>
                        </tr>
                    </table>
                </div>

           )
        );
    }

    static renderContentDetails(categoryDetails) {
        if (categoryDetails.contents != null) {
            return (
                categoryDetails.contents.map((contentDetails) =>
                    <table id="content_category" aria-labelledby="tableLabel">
                        <tbody>
                            <tr>
                                <td id="details_spacecol"></td>
                                <td id="details_col2">{contentDetails.name}</td>
                                <td id="details_col3">${contentDetails.value}</td>
                                <td id="details_spacecol"></td>
                               <td id="details_col4">
                                    <button variant="danger" onClick={() => this.deleteItem(contentDetails.contentItemId)}>Delete</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                )
            );
        }
   }

    static renderAddForm(categories) {
        return (
            <div id="additemform">
                    <table id="additemform">
                        <tr>
                            <td id="addform_spacecol"></td>
                            <td><label htmlFor="itemname">Item Name: </label><input id="itemname" type="text" placeholder="Enter Item Name" ref={(itemname) => this.itemname = itemname} /></td>
                            <td id="addform_spacecol"></td>
                            <td><label htmlFor="itemvalue">Value: </label><input id="itemvalue" type="text" placeholder="Enter Value of Item" ref={(itemvalue) => this.itemvalue = itemvalue} /></td>
                            <td id="addform_spacecol"></td>
                            <td><label htmlFor="itemcategory">Select a category: </label><div><select id="itemcategory" ref={(itemcategory) => this.itemcategory = itemcategory} >{this.renderCategoryDropdown(categories)}</select></div></td>
                            <td id="addform_spacecol"></td>
                            <td><input type="submit" value="Submit" onClick={() => this.handleSubmit()} /></td>
                        </tr>
                    </table>
            </div>
        );
    }

    static renderCategoryDropdown(categories) {
        return (
            categories.map((c) =>
                <option key={c.categoryId} value={c.categoryName}>{c.categoryName}</option>
            )
        );
    }

    render() {
    let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : ContentLimitCalc.renderContentTable(this.state.viewModel.contentsList, this.state.viewModel.categoryList);
        
            return (
        <div>
        <h1 id="tableLabel" >My Contents List</h1>
        <p>Manage your darkest home contents and their values here</p>
        {contents}
        </div>
        );
    }

    async populateContentsList() {
    const response = await fetch('ContentsList');
        const model = await response.json();
        this.setState({ viewModel: model, loading: false });
    }
}
