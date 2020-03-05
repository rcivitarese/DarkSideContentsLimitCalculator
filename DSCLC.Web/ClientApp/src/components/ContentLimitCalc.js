import React, { Component } from 'react';

export class ContentLimitCalc extends Component {
    static displayName = ContentLimitCalc.name;

    constructor(props) {
        super(props);
        this.state = { refresh: false, viewModel: null, loading: true };
    }

    handleSubmit() {
        var formData = new FormData();
        if (this.itemname.value.length != 0 &&
            this.itemvalue.value.length != 0) {
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
            }).then(
                response => response.text())
                .then(() => {
                    this.setstate = { loading: true};
                    this.componentDidMount();
                });


        } else {
            alert("You must enter a value for Name or Value.");
        }
    }

    deleteItem(itemId) {
        fetch('ContentsList/' + itemId, {
            method: 'delete'
        }).then(
            response => response.text())
            .then(() => {
                this.setstate = { loading: true };
                this.componentDidMount();
            });
    }

    componentDidMount() {
        this.populateContentsList();
    }

    renderContentTable(contentsList, categories) {
        return (
            <>
                <div>{this.renderCategoryContents(contentsList)}</div>
                <div>{this.renderAddForm(categories)}</div>
            </>
        );
    }

    renderCategoryContents(contentsList) {
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
                                {this.renderContentDetails(category)}
                           </td>
                        </tr>
                    </table>
                </div>

           )
        );
    }

    renderContentDetails(categoryDetails) {
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

    renderAddForm(categories) {
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

    renderCategoryDropdown(categories) {
        return (
            categories.map((c) =>
                <option key={c.categoryId} value={c.categoryName}>{c.categoryName}</option>
            )
        );
    }

    render() {
    let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : this.renderContentTable(this.state.viewModel.contentsList, this.state.viewModel.categoryList);
        
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
        this.setState({viewModel: model, loading: false });
    }
}
