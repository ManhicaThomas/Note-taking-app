from flask import render_template, flash, redirect, url_for
from app import app
from app.forms import NoteForm

@app.route('/')
@app.route('/index')
def index():
    return render_template('index.html', title='Home')

@app.route('/note', methods=['GET', 'POST'])
def note():
    form = NoteForm()
    if form.validate_on_submit():
        flash(f'Note created for {form.title.data}')
        return redirect(url_for('index'))
    return render_template('note.html', title='Create Note', form=form)

